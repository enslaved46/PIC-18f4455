/* author :ashish
   lab : measure temp and use sensor
   --gives average of 1000 collected data
  using 10 bit ADC 
  Temperature Sensor Used LM35
*/

#include <18F4455.h>
#device ADC=10     //10-bit ADC (0-1023 for 0-5 volts)
#device ICD=TRUE
#fuses HSPLL,NOWDT,NOPROTECT,NOLVP,NODEBUG,USBDIV,PLL5,CPUDIV1,VREGEN  
#use delay(clock=48000000) 
#use RS232(UART1, BAUD=115200, PARITY=N, BITS=8, STOP=1, TIMEOUT = 500)
#include <lcd.c>
#include <kbd_yz.c>

int lcd_flicker_control = 0;
char key;
int16 adc_read_value = 0;

float reading_in_float, converted_voltage , temp_Degree , Temperature_sum, average_temp_per_1000 =0;
int start_sample_flag , display_temp_flag, display_GUI, display_LCD=0;

#INT_TIMER1
void control_lcd_display(){
      set_timer1( get_timer1());
      lcd_flicker_control++;
}

#INT_EXT
void keydown_isr(){
    key=kbd_getc();
}

void enable_keypad(){ 
   key=0;                         // these 5 statements reset interrupt
   set_tris_D(0x1E);
   kbd=0x1E;
   clear_interrupt(INT_EXT);
   enable_interrupts(INT_EXT);
}

void display_sample_temp(){
   if (start_sample_flag==1){
         //taking thousand samples
         for (int16 i=0;i<=1000;i++){
               adc_read_value =  read_adc();      // conversion time is about 20 us.
               reading_in_float = (float)adc_read_value;
               converted_voltage = reading_in_float *  (5/1023);//in volts with respect to 5
               temp_Degree = ( converted_voltage * 100); // in celsius
               Temperature_sum = Temperature_sum +  temp_Degree;              
         }
      
         average_temp_per_1000 = Temperature_sum /1000;
 }     
  
// lcd was flickering to much 
//delaying
if ((lcd_flicker_control > 80 &&  display_temp_flag == 1)){
      disable_interrupts(INT_EXT);
      if (display_LCD!=1){
            lcd_putc("\f");
            printf (lcd_putc,"%.2f C ",average_temp_per_1000 );//LCD diaplay
      }
      if (display_GUI!=1){
            printf ("\r\n%.2f ",average_temp_per_1000 );
      }
 lcd_flicker_control = 0;
 enable_keypad();
}
  
}


void main()   {
  
  
   lcd_init();
   kbd_init();
   
   lcd_putc("ECE 422\n");
   lcd_putc("Ashish Khadka");
   printf("Ashish Khadka");
   
   ext_int_edge(0,L_to_H);     // set external interrupt
   enable_keypad();
   
   setup_adc_ports( AN0_ANALOG );  
   setup_adc( ADC_CLOCK_INTERNAL ); 
   set_adc_channel( 0 );             

   setup_timer_1(T1_INTERNAL|T1_DIV_BY_1);   // setup interrupts
   enable_interrupts(INT_TIMER1);
   enable_interrupts(GLOBAL);
   

   while (TRUE)   {
         Temperature_sum = 0;
         average_temp_per_1000=0;
         
         if(kbhit())                            // Checks  from serial
            {
               key = getc();
            }
            
   if(key!=0){
        disable_interrupts(INT_EXT);          
  
      switch (key){
              case '*':
               
                        disable_interrupts(INT_EXT);  
                        start_sample_flag =1;
                       
                        display_GUI=0;
                        display_LCD=0;
                        lcd_putc("\f");
                        lcd_putc("Sampling started");
                        printf("\nSampling started");
                        enable_keypad();
                        break;
                  
   
            case '3':
                  
                        disable_interrupts(INT_EXT);
                       display_temp_flag = 1;
                        display_GUI=0;
                        display_LCD=0;
                        enable_keypad();
                        break;
                  
               
            case '4':
   
                         disable_interrupts(INT_EXT);
                         
                       display_temp_flag = 1;
                        display_LCD=1;
                        display_GUI=0;
                        lcd_putc("\f");
                        enable_keypad();
                        break;
                        
   
            case '5':
   
                         disable_interrupts(INT_EXT);
                        
                       display_temp_flag = 1;
                        display_GUI=1;
                        display_LCD=0;
                        ;
                        enable_keypad();
                        break;
                        
                        
                  case '#':
                 
                        disable_interrupts(INT_EXT);
                        display_temp_flag = 0;
                        display_GUI=0;
                        display_LCD=0;
                        start_sample_flag =0;
                        lcd_putc("\f");
                        lcd_putc("Sampling stopped");
                        printf("\nSampling stopped");
                       enable_keypad();
                       break;
                 
   }
     
   enable_keypad();
   
   }
     
     display_sample_temp();
   }
}


