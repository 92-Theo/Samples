#define RF_433_GND 5
#define RF_433_VCC 2
#define RF_433_DATA 4

#define RF_315_GND 10
#define RF_315_VCC 13
#define RF_315_DATA 12

#define BUZZER_VCC 8
#define BUZZER_GND 7

#define RF_COUNT2_MIN 1

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

//  Serial.begin(250000);
//  Serial.println("init");
}
int rf_433_count = 0; // 연속적인 디지털값 1000회 이상
int rf_433_count2 = 0; // rf_433_count 횟수

int rf_315_count = 0;
int rf_315_count2 = 0;

void loop(){
// Signal Test
//  Serial.println(digitalRead(RF_315_DATA));
//
  if (digitalRead(RF_433_DATA) == 1){
    rf_433_count++;
  }else{
    if (rf_433_count != 0){
      if( rf_433_count > 1000){
        rf_433_count2++;
//        Serial.println(rf_433_count);
      }
      rf_433_count = 0;
    }
  }

  if (digitalRead(RF_315_DATA) == 1){
    rf_315_count++;
  }else{
    if (rf_315_count != 0){
      if( rf_315_count > 1000){
        rf_315_count2++;
//        Serial.println(rf_315_count);
      }
      rf_315_count = 0;
    }
  }

 if(millis()-timeVal>=1000){ //1초단위로 출력
     timeVal=millis();
     Serial.print("RF 433 Count : "); Serial.println(rf_433_count2);
     Serial.print("RF 315 Count : "); Serial.println(rf_315_count2);

     if (rf_433_count2 > RF_COUNT2_MIN){
       digitalWrite(BUZZER_VCC, HIGH);
     } else if (rf_315_count2 > RF_COUNT2_MIN){
       digitalWrite(BUZZER_VCC, HIGH);
     } else{
       digitalWrite(BUZZER_VCC, LOW);
     }

     rf_315_count2 = 0;
     rf_433_count2 = 0;
 } 
}
