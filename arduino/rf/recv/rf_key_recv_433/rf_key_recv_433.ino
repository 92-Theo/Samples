#define RF_433_GND 5
#define RF_433_VCC 2
#define RF_433_DATA 4

#define RF_315_GND 10
#define RF_315_VCC 13
#define RF_315_DATA 12

#define BUZZER_VCC 8
#define BUZZER_GND 7

#define RF_COUNT_GAP 1500
//#define DEBUG_MODE 1

unsigned long timeVal = 0; //이전시간
unsigned long millisTime = 0; //현재시간
unsigned long countTime = 0; //카운트시작시간

void setup(){
  pinMode(RF_433_GND, OUTPUT);
  pinMode(RF_433_VCC, OUTPUT);
  pinMode(RF_433_DATA, INPUT);
  digitalWrite(RF_433_GND, LOW);
  digitalWrite(RF_433_VCC, HIGH);

  pinMode(RF_315_GND, OUTPUT);
  pinMode(RF_315_VCC, OUTPUT);
  pinMode(RF_315_DATA, INPUT);
  digitalWrite(RF_315_GND, LOW);
  digitalWrite(RF_315_VCC, HIGH);

  pinMode(BUZZER_VCC, OUTPUT);
  pinMode(BUZZER_GND, OUTPUT);
  digitalWrite(BUZZER_VCC, LOW);
  digitalWrite(BUZZER_GND, LOW);

#ifdef DEBUG_MODE
    Serial.begin(250000);
    Serial.println("init");
#endif

  digitalWrite(BUZZER_VCC, HIGH);
  delay(2000);
  digitalWrite(BUZZER_VCC, LOW);

}
unsigned long rf_433_count = 0; // 연속적인 디지털값 1000회 이상
unsigned long prev_rf_433_count = 0; // rf_433_count 횟수

unsigned long rf_315_count = 0; // 연속적인 디지털값 1000회 이상
unsigned long prev_rf_315_count = 0; // rf_433_count 횟수


void loop(){
// Signal Test
//  Serial.println(digitalRead(RF_315_DATA));
//
  if (digitalRead(RF_433_DATA) == 1){
    rf_433_count++;
  }

  if (digitalRead(RF_315_DATA) == 1){
    rf_315_count++;
  }
  
 if(millis()-timeVal >= 200){ //1초단위로 출력
       long gap_433 = rf_433_count - prev_rf_433_count;
       long gap_315 = rf_315_count - prev_rf_315_count;

#ifdef DEBUG_MODE
       Serial.print(rf_433_count); 
       Serial.print(" : ");
       Serial.print(rf_315_count);

       Serial.print(" >>> ");

       Serial.print(gap_433); 
       Serial.print(" : ");
       Serial.println(gap_315);
#endif
       
      if (gap_433 > RF_COUNT_GAP){
#ifdef DEBUG_MODE
        Serial.println("433 Buzzer ON");  
#endif
        digitalWrite(BUZZER_VCC, HIGH);
        delay(500);
        digitalWrite(BUZZER_VCC, LOW);

#ifdef DEBUG_MODE
        Serial.println("433 Buzzer OFF");  
#endif

      }
      else if (gap_315 > RF_COUNT_GAP){
#ifdef DEBUG_MODE
        Serial.println("315 Buzzer ON");  
#endif
        digitalWrite(BUZZER_VCC, HIGH);
        delay(500);
        digitalWrite(BUZZER_VCC, LOW);
#ifdef DEBUG_MODE
        Serial.println("315 Buzzer OFF");  
#endif

       
      }

      prev_rf_433_count = rf_433_count;
      prev_rf_315_count = rf_315_count;
    
      rf_433_count = 0;
      rf_315_count = 0;     
      timeVal=millis();
 } 
}
