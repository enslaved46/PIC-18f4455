//Author: Ashish Khadka
//Class :ECE 422
//Lab : 2

#include <18F4455.h>
#fuses HS, NOWDT, NOPROTECT, NOLVP
#use delay(clock=20000000, crystal=20 MHz)/*Defining Clock speed*/
#include <lcd.c>
#include <string.h>
#include <math.h>

#include <stdlib.h> 
#include <kbd.c>

#define FIRST_LED PIN_A0
#define SECOND_LED PIN_A1
#define THIRD_LED PIN_A3

//void load();
void calc();
void load();
void turn_on(int led) ;
void led_display();

void main() {
char k;

lcd_init();
 kbd_init(); 
 load();
led_display();
 

while(True){
 
 k=kbd_getc();
    if(k!=0)
       if(k=='*'){
         lcd_putc('\f');
       }
       else{
calc();}
}
}

void calc(){

signed int first_num=0;
signed int sec_num =0;
char k;
char task;
char loop1='T';

char operation;
signed int result=0;
int loop=0;
int instruction=0;
int check;

lcd_init();
kbd_init();
       while(loop1=='T'){
        
              k=kbd_getc();
       
          //char to int
          check=k-'0';  
               if((check>=0)&&(check<=9)){
                     if(loop==0){
                         first_num=check;
                         lcd_putc(k);
                         loop++;
                     }
                      
                     else if(loop==2){
                        sec_num=check;
                        lcd_putc(k);
                        loop++;
                        loop1='F';
                      }
         }
              
               else if(k=='*'){
                         lcd_putc('\f');
                         loop1='T';
                         loop=0;
                         }
                       
                       else if (k=='#'&& instruction==0){
                             
                             lcd_putc('+');
                             instruction++;
                             loop++;
                             operation='+';
                       }
                       else if (k=='#'&&instruction==1){
                              lcd_putc('\b');
                              lcd_putc('-');
                              instruction++;
                              operation='-';
                       }
                       
                          else if (k=='#'&& instruction==2){
                                lcd_putc('\b');
                             lcd_putc('*');
                             instruction++;
                             operation='*';
                       }
                       else if (k=='#'&&instruction==3){
                              lcd_putc('\b');
                              lcd_putc('/');
                              instruction=0;
                              operation='/';
                              if(k=='#'){
                                 lcd_putc('\b');
                                 //loop--;
                              }
                              
                       }
       }
       
        switch(operation){
            
            case '+':
               task='+';
               result=first_num+sec_num;
               lcd_putc(result);        
               break;
              
            case '-':
               task='-';
               result=first_num-sec_num;
               lcd_putc(result);
               lcd_putc(result);         
               break;
               
             case '*':
               task='*';
               result=first_num*sec_num;
               lcd_putc(result); 
               break;

             case '/':                 
               task='/';
               result=first_num/sec_num;
               lcd_putc(result);
               break;
         }
             
//dconvert to ascii
first_num='0'+first_num;
//result='0'+result;
sec_num='0'+sec_num;
              lcd_putc('\f'); //clear screen
          
            lcd_putc(first_num);
            lcd_putc(task);
            lcd_putc(sec_num);
            lcd_putc('=');
            lcd_putc('\n');
            printf(lcd_putc,"%d",result);
            //delay_ms(50);
       
       }
                              



void load()
{
 int i=0;
 int str_length=0;

  char name[100];
 int f_cur=16;
 
 int j=0;
 strcpy(name, "Thank YOu Travis. You are the MAN! :) :)");
 str_length = strlen(name);
 
 while(i<= str_length) {
    
    while(j<=i){
         lcd_gotoxy(f_cur,1);
        printf(lcd_putc,"%c",name[j]);
         f_cur=f_cur+1;
         j=j+1;
 }
f_cur=16-i;
delay_ms(10);

 j=0;
 i++;
 }
}

 

void turn_on(int led) 
{
   switch(led) {
         case 0 :
                 
         output_toggle(FIRST_LED);
         break;
 
         case 1 : 
           
           output_toggle(SECOND_LED);
           break;
            
         case 2 :
             output_toggle(THIRD_LED);
             break;
         
         
}
   }
   
   void led_display(){
   int i=20;
  while( i>0){
         turn_on(0);   
  
 
          turn_on(1);
   
         turn_on(2);
        i--;
         delay_us(10000);
   }
   output_high(FIRST_LED);
   output_high(SECOND_LED);
   output_high(THIRD_LED);
   
   }


   
