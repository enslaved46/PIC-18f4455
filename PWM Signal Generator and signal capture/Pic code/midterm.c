#include <18f4455.h>
#FUSES NOWDT //No Watch Dog Timer
#FUSES NOPROTECT //Code not protected from reading
#FUSES NOBROWNOUT //Reset when brownout detected
#FUSES PUT //No Power Up Timer
#FUSES NODEBUG //No Debug mode for ICD
#FUSES NOWRT //Program memory not write protected
#FUSES NOLVP //No Low-Voltage ICSP Programming
#FUSES HSPLL // High-Speed Crystal with PLL enabled
#FUSES PLL5 //PLL prescaler set to 5
#FUSES CPUDIV1 //no postscaler
#use delay(clock = 48Mhz, crystal = 20Mhz)
#use RS232(UART1, BAUD=115200, PARITY=N, BITS=8, STOP=1, TIMEOUT = 500)

#define OUTPUT_PIN PIN_A3
#include "kbd_yz.c"
#include <lcd.c>

//declare variables
char key_p;Int32  on_time_us;//=0;
int key_flag=0;
float freq=0; float period=0;
Int16 TN,TN_O,TN_on_c,TN_off_c;  int signal_flag=1;float on_c,off_c=0;
int counter=0;
int32 count_overflow_on,count_overflow_off=0;

#INT_EXT
void key_pad(){
key_p=kbd_getc();                                                               //get character from key board
key_flag=1;                                                                     //set flag
}

#INT_RDA
void key_board(){ 
    key_p=getc();                                                               //get character from key board
    key_flag=1;                                                                 //set flag
    }
//initialize timer 0
#INT_TIMER0
void waveform(){
           counter++;                                              //increment counter with every interrupt
           switch(signal_flag){                                    //check signal flag
      
           case 1:
                     if(counter==count_overflow_off){             //check the counter matches on overflow_off int
                         signal_flag=2;                           //set flag
                         counter=0;                               //reset counter
                         set_timer0( TN_off_c+get_timer0());      //start counter for off residue count
               }  
                      else
                        set_timer0(get_timer0());                 //if condition does not matches start timer from 0
           break;
           
           case 2:
       
                     output_toggle(OUTPUT_PIN);                   //change the output to high
                     signal_flag=3;                               // set signal flag
                     counter=0;                                   //reset counter
                     set_timer0(get_timer0());                    //start timer0 forr 0
               
                  break;

          case 3:
                           if(counter==count_overflow_on){        //check the counter matches on overflow_off int
                           signal_flag=4;                         //set flag
                           counter=0;                             //reset counter
                           set_timer0( TN_on_c+get_timer0());     //set timer from on residue count
                                  
                         }
                         else
                               set_timer0(get_timer0());          //start timer0 forr 0
             
           break;
           
           case 4:
                        output_toggle(OUTPUT_PIN);                 //change the output to high
                        signal_flag=1;                             //set flag
                        counter=0;                                 //reset counter
                        set_timer0( get_timer0());                 //start timer0 from 0
               
             break;              
       
           }   
           }
}
 
 

//ccp pin interrupt 
#int_ccp1
void isr(){

set_timer1(0);                                           //start timer from 0
if(flag==0)
{
   rise = CCP_1;                                         //get timer value for rise
   setup_ccp1(CCP_CAPTURE_FE);                           //set capture flag for falling edge
   pulse_width2 =  Down_Count_CCP*65535 + rise +156;    //measure the fall-rise time
   Down_Count_CCP=0;                                     //reset down count 
   flag=1;                                               //set flag

}

 else if(flag==1)
      {
         set_timer1(0);                                  //start timer from 0
         fall = CCP_1;                                   //get timer value for rise
         setup_ccp1(CCP_CAPTURE_RE);                     //set capture flag for falling edge
         pulse_width1 = UP_Count_CCP*65535 + fall +156; //measure the rise-fall time
        UP_Count_CCP=0;                                   //reset up count     
         flag=0;                                         //set flag
      }  
}

 
void clear_garbage(){
                        key_p=0;                            //clear key
                        key_flag=0;                         // clear flag    
                        freq=0;                             //clear frequency
                        state=0;                            // change sate to 0
                        on_time_us=0;                       //clear on duty
                        output_low(OUTPUT_PIN);             //set output low 
                        printf("Reset performed\n");        //print message
                        lcd_putc('\f');                     //clear lcd
                        printf(lcd_putc,"Enter frequency \n"); //print in lcd
                        delay_us(20);                          //delay 20 microsecond
                        disable_interrupts(INT_TIMER0);        //disable timero interrupt
                        signal_flag=0;                         //clear flag
                                                    
                   }



void enable_board();

void enable_keyp();



void main(){
Int16 temp=0;
Int16 temp1 ;//=0;
output_low(OUTPUT_PIN);
lcd_init();
kbd_init();
int duty_c=0;
int state=0;
enable_keyp();
enable_board();
lcd_putc("Midterm");

enable_interrupts(INT_EXT);             //enable external interrupt
enable_interrupts(INT_RDA);             //enable serial interrupt
SETUP_TIMER_0(T0_INTERNAL | T0_DIV_1);  //setup timer with prescalar 1  @ 12 MHZ
SETUP_TIMER_1(T1_INTERNAL);            // set up timer 1 @ 12 MHZ
setup_ccp1(CCP_CAPTURE_RE);            //set up ccp1 for rising edge
enable_interrupts(int_ccp1);           //enable ccp1 interrupt
enable_interrupts(int_timer1);         //enable timer 1 interrupt
enable_interrupts(int_timer0);         //enable timer 0 interrupt
enable_interrupts(GLOBAL);              //enable global interrupt

 


 //  printf(lcd_putc,"\fMidterm \n");
while(true){
 
  if(key_p!=0&&key_flag==1){
  disable_interrupts(INT_EXT);

      temp1=key_p-'0'; //convert char to int
      key_flag=0;      //disable flag
       
      
             switch(state){
                  
                     case 0:
                            if(key=='*'){
                                         printf("\r\nEnter Frequency: \n\r"); //user promt message for GUI
                                         lcd_putc("\fEnter Frequency:\n");    //user promt message for LCD
                                         state=1;
                                                }
                             else {
                                    printf("midterm");                      //user promt message for if user dont press *
                                    sate =0;                                //go back to same sate
                             }
                     break;
                                               
                      case 1:
                                      
                                                 
                             if(key_p!='c'&&key_p>='0'&&key_p<='9'){       //check the input is number
                                  if(freq<=1000){                          //making sure freqeuney is under domian
                                     freq=(freq*10)+temp1;                 //shift by 10th for eveyr input
                               
                                     printf(lcd_putc,"%c",key_p);          //print the key in lcd
                                     printf("%c",key_p);                   //print in gui
                                     delay_us(20);                         //delay 20 micorsecond
                                     state = 1;                            //go to sate 1
                                   }
                                  
                             
                                 else (freq>1000) {                        //if entered freq over 100
                                       printf("\r\ndomain Error");         // print domain error
                                       freq=0;                             //reset freqeuency
                                       state=1;                            //go back to same sate
                                  }
                             }
                        
                             else if(key_p=='c'){                          // check for special characet
                                    clear_garbage();                       //clean all the variables
                     
                             }
                 
                                              
                              else if (key=='*'){                          //if *
                                        printf("a");                       //sen d special character to gui
                                        delay_ms(300);                     //delay 300 milli seccond
                                        lcd_putc("\fEnter Duty \n");       //ask for duty cycle in LCD
                                        printf("\r\nenter Duty\n ");       //ask for duty cycle in GUI
                                        key=0;                             //reset key
                                        state_gen=2;                       //move to next state
                              }
                                              
                      break;
                  
                      case 2:
                               if(key_p=='c'){                             // check for special characet
                                   clear_garbage();                         //clean all the variables
                     
                               }
                               
                                else if(key_p!='c'&&key_p>='0'&&key_p<='9'){ //check the input is number
                                         temp1=key_p-'0';                    //convert char to int
                                         if(duty_c<100){                      //check if duty clcue is less than 100%
                                             duty_c=(duty_c*10)+temp1;        //shift by 10th
                                             printf(lcd_putc,"%c",key_p);     //print entered key in lcd
                                             delay_us(20);                    //delay to debounce
                                            state = 2;                        //move to next sate
                                         }
                                 }
                                else if (key_p=='*'){                         //if *
                                          printf("\r\nGenerating pulse");    //print message
                                          lcd_putc("\fGenerating pulse");    //print message
                                          delay_us(20);                      //delay 20 microseocnd
                                          period=1000000/freq;               //converting into microsecond
                                          on_time_us=(float)duty_c*(period)  //100;//on time duty cycle in microsecond
                                          on_c =duty_c*(period)/100;;         // get on duty time  
                                          TN = 65535 - on_time_us*12+12; //count ticks to keep the signal on
                                          TN_O=65535 - (period-on_time_us)*12+12; //off time ticks
                                          count_overflow_on=(on_time_us)/5461.25; //count number of overflows in integeres if there is one integer
                                          count_overflow_off=(period-on_time_us)/5461.25; //count number of over flow for off duty gives integer 
                                          on_c=(on_c)/5461.25;                   //calculate on residue
                                          off_c=(period-on_time_us)/5461.25;    //calculate off residue
                                          on_c = on_c-(long)on_c;               //getting float for residue for on
                                          off_c = off_c-(long)off_c;              //getting float for residue for off
                                          TN_on_c=on_c;                          
                                          TN_off_c=off_c;
                                          TN_on_c=65535-TN_on_c*65535*12;        //calculate on ticks for overflow
                                          TN_off_c=65535-TN_off_c*65535*12;      //calculate ooff ticks for overflow
                                           key_p=0;                               //clear key
                                          state=3;                               //move to next state
                                          enable_interrupts(INT_TIMER0)          //state timer 0
                                          
                                         
                                }
                     break;
                
            
                     case 3:
                              if(key_p=='#'){                                //check for #
                                    printf("a");                              //sen d special character to gui 
                                    count_high=0;                             //reset counter for capture
                                    count_low=0;                              //reset counter for capture
                                    enable_interrupts(int_ccp1);              //enable ccp interrupt
                                    delay_ms(3000);                           //dleay to run one time period of pulse
                                    PW1=pulse_width1;                         //caputer pulse timer value
                                    delay_ms(3000);                            //dleay to run one time period of pulse
                                    PW2=pulse_width2;                          //caputer pulse timer value
                                    disable_interrupts(int_ccp1);             //diaable ccp interrupt
                                    disable_interrupts(int_timer1);           //disable timer
                                    measured_f=12000000/(PW1+PW2);            //calculate measured freqeuecny
                                    printf(lcd_putc,"\ffrequency: \n%lu",measured_f);  //print frequency in LCD
                                    printf("%lu",measured_f);                 //print measured freqeuency in GUI
                                    key=0;                                    //clear key
                                    state=4;                                  //move to next sate
                                   
                              }
                              else if(key=='c'){
                                        clean_garbage();
                              }
                    
                    break;
          }
          
                              
                                                    
               case 4:    
                        if(key=='#'){                                   //check for #
                                     printf("a");                        //sen d special character to gui   
                                    printf(lcd_putc,"Rise = %lu us ",PW1/12);  //meauser positive pulse width
                                     printf("%lu",PW1/12);                     //print measure value
                                     key_p=0;                                 //reset key
                                     state=5;                              //move to next sate
                                                     } 

                         else if(key=='c'){                             
                                      clean_garbage();   
                         }
                 break;
                 
                                         
                case 5:                
                         if(key=='#'){                                   
                                      printf("a");                   //send special character from gui 
                                       measured_d=(PW1)*100/(PW1+PW2);    //measure duty cycle
                                      lcd_putc("\fDuty Cycle:\n");         //print message
                                                           
                                      printf(lcd_putc,"\n%ld", measured_d);   //print measure duty cucle in lcd
                                       printf("\%ld", measured_d);            //print measure dutycyle in GUI
                                       key_p=0;                               //reset gui
                                                 
                          }
                                                  
                           else if(key=='c'){                        //if c
                                        clean_garbage();             //clean variables
                           }
                           
                           else if(key=='*'){
                                         printf("\r\nEnter Frequency: \n\r"); //diplay the message in gui
                                         lcd_putc("\fEnter Frequency:\n");    //display in lcd
                                         state=1;                             //go to sate 1
                           }
                break;
         
               }
      enable_keyp();

   }
}

//enable bluetooth
void enable_board(){
   clear_interrupt(INT_RDA);     // register/output keep old values, need to be cleared
   enable_interrupts(INT_RDA);     // these 5 statements may be grouped in a function
}

//enable keypad
void enable_keyp(){
                          // these 5 statements reset interrupt
// key_b=0;
      set_tris_D(0x1E);
      kbd=0x1E;
      clear_interrupt(INT_EXT);     //celar external interrupt
      enable_interrupts(INT_EXT);     //enable external interrupt
  }