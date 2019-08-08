// The original kdb_get.c  was modified  by   Professor Zheng ,        9/15/2012
// The modification allows the detection completed in one function call. The original kdb_get.c  is called once for one
// column scan.  It does not allow the external interrupt and was not work reliably if there are many other operations in 
// the main loop. The program is also simplified for study purposes.

#byte kbd = getenv("SFR:PORTD")

char const KEYS[4][3] = {{'1','2','3'},
                      	               {'4','5','6'},
                                            {'7','8','9'},
                                            {'*','0','#'}};
void kbd_init() {}

char kbd_getc( ) {
   static int1 kbd_down;
   static char last_key;
   static BYTE col;
   int1 idd;

   BYTE kchar;
   BYTE row;
   kchar='\0';
   idd = 0;
   
   while(idd==0){
       set_tris_d(0xFE);
      delay_us(100);           				// This delay adds de-bounce 
       if (col == 0) {set_tris_d(0xDE); kbd=0xDE;}                  // set D1, 1st col, low.      
       else if (col == 1) {set_tris_d(0xBE); kbd=0xBE;}           // set D2, 2nd col, low
       else if (col == 2) {set_tris_d(0x7E); kbd=0x7E;}           // set D3, 3rd column to low
       if(kbd_down) {
         if((kbd & 0x1E)==0x1E) {
           kbd_down=FALSE;
           kchar=last_key;
           last_key='\0';
           idd = 1;
         }
       } else {
          if((kbd & 0x1E)!=0x1E) {                     // if a key is pressed, one of row will be low
             if((kbd & 0x02)==0) row=0;
             else if((kbd & 0x04)==0) row=1;
             else if((kbd & 0x08)==0) row=2;
             else if((kbd & 0x10)==0) row=3;
             last_key =KEYS[row][col];
             kbd_down = TRUE;
          } else {
             ++col;
             if(col==3) col=0;
          }
       }
   }
  return(kchar);
}
