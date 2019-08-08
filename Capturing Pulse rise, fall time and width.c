/* Using CCP pin to capture rise and fall time
 Also caputres pluse width
*/

#if defined(__PCM__)

#include <16F877.h>

#fuses HS,NOWDT,NOPROTECT,NOLVP

#use delay(clock=20000000)

#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)

#elif defined(__PCH__)
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
#endif

#include <lcd.c>

int flag=0;
long rise,fall,pulse_width1,pulse_width2=0;

#int_ccp1
void isr(){

if(flag==0)
{
rise = CCP_1;
setup_ccp1(CCP_CAPTURE_FE);
pulse_width2 = rise-fall; //measure the fall-rise time
flag=1;

}

else if(flag==1){
fall=CCP_1;
setup_ccp1(CCP_CAPTURE_RE);
pulse_width1 = fall-rise; //measure the rise-fall time
flag=0;
}

}

void main(){

printf("\n\rHigh time (sampled every second):\n\r");
lcd_init();
int32 a,b=0;
flag=0;
setup_timer_1(T1_INTERNAL);
enable_interrupts(int_ccp1);
setup_ccp1(CCP_CAPTURE_RE);
enable_interrupts(GLOBAL);

   while(TRUE) {
      delay_ms(2000);

    
     // a=(pulse_width1/12)+0x30;

     
    //// lcd_putc(a);
  
      printf("\r\n Fall-rise time= %ld us ", pulse_width2/12 );
    
     // delay_ms(300);
      
      printf("\r\n Rise-fall time = %ld us ", pulse_width1/12 );
   //   b=(pulse_width2/5) +0x30;
     // delay_ms(300);
      
      printf(lcd_putc,"\fFall-rise = %ld", pulse_width2/12);
      printf(lcd_putc,"\nRise-fall = %ld us ",pulse_width1/12);
    // delay_ms(300);
//  lcd_putc(b);
      }
}

