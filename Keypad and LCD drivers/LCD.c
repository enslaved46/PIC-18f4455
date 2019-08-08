///////////////////////////////////////////////////////////////////////////
////                             LCDD.C                                ////
////                 Driver for common LCD modules                     ////
////                                                                   ////
////  lcd_init()   Must be called before any other function.           ////
////                                                                   ////
////  lcd_putc(c)  Will display c on the next position of the LCD.     ////
////                     The following have special meaning:           ////
////                      \f  Clear display                            ////
////                      \n  Go to start of second line               ////
////                      \b  Move back one position                   ////
////                                                                   ////
////  lcd_gotoxy(x,y) Set write position on LCD (upper left is 1,1)    ////
////                                                                   ////
////  lcd_getc(x,y)   Returns character at position x,y on LCD         ////
////                                                                   ////
///////////////////////////////////////////////////////////////////////////
////        (C) Copyright 1996,2007 Custom Computer Services           ////
//// This source code may only be used by licensed users of the CCS C  ////
//// compiler.  This source code may only be distributed to other      ////
//// licensed users of the CCS C compiler.  No other use, reproduction ////
//// or distribution is permitted without written permission.          ////
//// Derivative programs created using this software in object code    ////
//// form are not restricted in any way.                               ////
///////////////////////////////////////////////////////////////////////////

// As defined in the following structure the pin connection is as follows:
//     D0  enable
//     D1  rs
//     D2  rw
//     D4  D4
//     D5  D5
//     D6  D6
//     D7  D7
//
//   LCD pins D0-D3 are not used and PIC D3 is not used.

// Un-comment the following define to use port B
// #define use_portb_lcd TRUE

#include "LCD.h"
#include "board.h"

BYTE const LCD_INIT_STRING[4] = {0x20 | (LCD_TYPE << 2), 0xc, 1, 6};
                             // These bytes need to be sent to the LCD
                             // to start it up.

BYTE lcd_read_nibble(void);

BYTE lcd_read_byte(void)
{
   BYTE low,high;

 #if defined(__PCB__)
   set_tris_lcd(LCD_INPUT_MAP);
 #else
  #if (defined(LCD_DATA4) && defined(LCD_DATA5) && defined(LCD_DATA6) && defined(LCD_DATA7))
   output_float(LCD_DATA4);
   output_float(LCD_DATA5);
   output_float(LCD_DATA6);
   output_float(LCD_DATA7);
  #else
   lcdtris.data = 0xF;
  #endif
 #endif
        
   lcd_output_rw(1);
   delay_cycles(1);
   lcd_output_enable(1);
   delay_cycles(1);
   high = lcd_read_nibble();
      
   lcd_output_enable(0);
   delay_cycles(1);
   lcd_output_enable(1);
   delay_us(1);
   low = lcd_read_nibble();
      
   lcd_output_enable(0);

 #if defined(__PCB__)
   set_tris_lcd(LCD_OUTPUT_MAP);
 #else
  #if (defined(LCD_DATA4) && defined(LCD_DATA5) && defined(LCD_DATA6) && defined(LCD_DATA7))
   output_drive(LCD_DATA4);
   output_drive(LCD_DATA5);
   output_drive(LCD_DATA6);
   output_drive(LCD_DATA7);
  #else
   lcdtris.data = 0x0;
  #endif
 #endif

   return( (high<<4) | low);
}

BYTE lcd_read_nibble(void)
{
  #if (defined(LCD_DATA4) && defined(LCD_DATA5) && defined(LCD_DATA6) && defined(LCD_DATA7))
   BYTE n = 0x00;

   /* Read the data port */
   n |= input(LCD_DATA4);
   n |= input(LCD_DATA5) << 1;
   n |= input(LCD_DATA6) << 2;
   n |= input(LCD_DATA7) << 3;
   
   return(n);
  #else
   return(lcd.data);
  #endif
}

void lcd_send_nibble(BYTE n)
{
  #if (defined(LCD_DATA4) && defined(LCD_DATA5) && defined(LCD_DATA6) && defined(LCD_DATA7))
   /* Write to the data port */
   output_bit(LCD_DATA4, bit_test(n, 0));
   output_bit(LCD_DATA5, bit_test(n, 1));
   output_bit(LCD_DATA6, bit_test(n, 2));
   output_bit(LCD_DATA7, bit_test(n, 3));
  #else      
   lcdlat.data = n;
  #endif
      
   delay_cycles(1);
   lcd_output_enable(1);
   delay_us(2);
   lcd_output_enable(0);
}

void lcd_send_byte(BYTE address, BYTE n)
{
  #if defined(__PCB__)
   set_tris_lcd(LCD_OUTPUT_MAP);
  #else
   lcd_enable_tris();
   lcd_rs_tris();
   lcd_rw_tris();
  #endif

   lcd_output_rs(0);
   while ( bit_test(lcd_read_byte(),7) ) ;
   lcd_output_rs(address);
   delay_cycles(1);
   lcd_output_rw(0);
   delay_cycles(1);
   lcd_output_enable(0);
   lcd_send_nibble(n >> 4);
   lcd_send_nibble(n & 0xf);
}

#if defined(LCD_EXTENDED_NEWLINE)
unsigned int8 g_LcdX, g_LcdY;
#endif

void lcd_init(void) 
{
   BYTE i;

 #if defined(__PCB__)
   set_tris_lcd(LCD_OUTPUT_MAP);
 #else
  #if (defined(LCD_DATA4) && defined(LCD_DATA5) && defined(LCD_DATA6) && defined(LCD_DATA7))
   output_drive(LCD_DATA4);
   output_drive(LCD_DATA5);
   output_drive(LCD_DATA6);
   output_drive(LCD_DATA7);
  #else
   lcdtris.data = 0x0;
  #endif
   lcd_enable_tris();
   lcd_rs_tris();
   lcd_rw_tris();
 #endif

   lcd_output_rs(0);
   lcd_output_rw(0);
   lcd_output_enable(0);
    
   delay_ms(30);
   for(i=0; i<3; i++)
   {
       lcd_send_nibble(3);
       delay_ms(10);
   }
   
   lcd_send_nibble(2);
   delay_ms(10);
   for(i=0; i<4; i++)
   {
      lcd_send_byte(0, LCD_INIT_STRING[i]);
      delay_ms(50);
   }

  #if defined(LCD_EXTENDED_NEWLINE)
   g_LcdX = 0;
   g_LcdY = 0;
  #endif
}

void lcd_gotoxy(BYTE x, BYTE y)
{
   BYTE address;
   
   if(y!=1)
      address=LCD_LINE_TWO;
   else
      address=0;
     
   address+=x-1;
   lcd_send_byte(0,0x80|address);

  #if defined(LCD_EXTENDED_NEWLINE)
   g_LcdX = x - 1;
   g_LcdY = y - 1;
  #endif
}

void lcd_putc(char c)
{
   switch (c)
   {
      case '\a'   :  lcd_gotoxy(1,1);     break;

      case '\f'   :  lcd_send_byte(0,1);
                     delay_ms(2);
                    #if defined(LCD_EXTENDED_NEWLINE)
                     g_LcdX = 0;
                     g_LcdY = 0;
                    #endif
                     break;

     #if defined(LCD_EXTENDED_NEWLINE)
      case '\r'   :  lcd_gotoxy(1, g_LcdY+1);   break;
      case '\n'   :
         while (g_LcdX++ < LCD_LINE_LENGTH)
         {
            lcd_send_byte(1, ' ');
         }
         lcd_gotoxy(1, g_LcdY+2);
         break;
     #else
      case '\n'   : lcd_gotoxy(1,2);        break;
     #endif
     
      case '\b'   : lcd_send_byte(0,0x10);  break;
     
     #if defined(LCD_EXTENDED_NEWLINE)
      default     : 
         if (g_LcdX < LCD_LINE_LENGTH)
         {
            lcd_send_byte(1, c);
            g_LcdX++;
         }
         break;
     #else
      default     : lcd_send_byte(1,c);     break;
     #endif
   }
}
 
char lcd_getc(BYTE x, BYTE y)
{
   char value;

   lcd_gotoxy(x,y);
   while ( bit_test(lcd_read_byte(),7) ); // wait until busy flag is low
   lcd_output_rs(1);
   value = lcd_read_byte();
   lcd_output_rs(0);
   
   return(value);
}

// write a custom character to the ram
// which is 0-7 and specifies which character array we are modifying.
// ptr points to an array of 8 bytes, where each byte is the next row of
//    pixels.  only bits 0-4 are used.  the last row is the cursor row, and
//    usually you will want to leave this byte 0x00.
void lcd_set_cgram_char(unsigned int8 which, unsigned int8 *ptr)
{
   unsigned int i;

   which <<= 3;
   which &= 0x38;

   lcd_send_byte(0, 0x40 | which);  //set cgram address

   for(i=0; i<8; i++)
   {
      lcd_send_byte(1, *ptr++);
   }
  
   #if defined(LCD_EXTENDED_NEWLINE)
    lcd_gotoxy(g_LcdX+1, g_LcdY+1);  //set ddram address
   #endif
}

void lcd_cursor_on(int1 on)
{
   if (on)
   {
      lcd_send_byte(0,0x0F);           //turn LCD cursor ON
   }
   else
   {
      lcd_send_byte(0,0x0C);           //turn LCD cursor OFF
   }
}
