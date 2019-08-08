//Author:modified by Ashish
//LAB 3: External interrupt calculator communicated by bluetooth 
//This program communicates with GUI with external interrupt 

#include <18F4455.h>
#device ICD=TRUE
#fuses HS,NOLVP,NOWDT,PUT
#use delay(crystal=20mhz, clock=20000000)
#use RS232(UART1, BAUD=115200, PARITY=N, BITS=8, STOP=1, TIMEOUT = 500)

#include <lcd.c>
#include "kbd.c"

#byte kbd = getenv("SFR:PORTD")     //Map PortD address, kbd is portD

static char key_p;
static int flag=0;

int state=0;


//keyboard interupt setup with bluetooth
#INT_RDA
void key_board(){
    key_p=getc();
    flag=1;
    }

//external keypad interrupt 
#INT_EXT
void key_pad(){
   key_p=kbd_getc();
   flag=1;
}

void enable_keyp(){
 key_p=0;                         // these 5 statements reset interrupt
// key_b=0;
      set_tris_D(0x1E);
      kbd=0x1E;
      clear_interrupt(INT_EXT);
      enable_interrupts(INT_EXT);
  }

void enable_board(){
   clear_interrupt(INT_RDA);     // register/output keep old values, need to be cleared
   enable_interrupts(INT_RDA);     // these 5 statements may be grouped in a function
}

void reset() {
   set_tris_D(0x01E);            // Set column output, row input
   kbd=0x1E;                     // Set all columns low, all rows high
   clear_interrupt(INT_EXT);     // register/output keep old values, need to be cleared
  enable_interrupts(INT_EXT);   // enabling external interrupt
}

void main()   {
int a,b,res,state = 0;
   char opr;

   lcd_init();
   kbd_init();
   lcd_putc("\f Enter Your Name Here \n");   
  key_p= 0;
    key_p= 0;
  ext_int_edge(0,L_to_H);       // set external interrupt
  enable_board();
  enable_keyp();
   enable_interrupts(GLOBAL);
   

   while (TRUE)   {
   //if hit in key pad
     if(flag){
     
      disable_interrupts(INT_EXT);
             switch(state){ 
               case 0:  printf("%c",key_p);
                        printf(lcd_putc,"\f%c",key_p);
                        a = key_p - 0x30;
                        state = 1;
                        printf("\r\nEnter the operator (+-*/): ");
                        break;
                        
               case 1: 
                        printf("%c",key_p);
                        printf(lcd_putc,"%c",key_p);
                        opr = key_p;
                        if(opr!='+'||opr!='-'||opr!='*'||opr!='/'){
                        state = 2;
                        printf("\r\nEnter the second number: ");
                        }
                        break;
                        
               case 2:  printf("%c",key_p);
                        printf(lcd_putc,"%c = ",key_p);
                        b = key_p - 0x30;
                        switch(opr){
                           case '+':   res = a + b;
                                       break;
                           case '-':   res = a - b;
                                       break;
                           case '*':   res = a * b;
                                       break;
                           case '/':   res = a / b;
                                       break;
                                                        
                           case '1':   res = a + b;
                                       break;
                                       
                           case '2':   res = a - b;
                                       break;
                                       
                           case '3':   res = a * b;
                                       break;
                           case '4':   res = a / b;
                                       break;
                                       
                        }
  
                            printf("\r\n%d %c %d = %d",a,opr,b,res);
                        printf(lcd_putc,"%d",res);

                       
                        printf("\r\nEnter the first number: ");
                        printf(lcd_putc,"\nEnter number:");
                        state = 0;    
                        break;
         }
         flag = 0;
      }
      reset();
      delay_ms(1);
   }
}

