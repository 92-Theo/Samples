#define RF_433_GND 5
#define RF_433_VCC 2
#define RF_433_DATA 4

void setup(){
  pinMode(RF_433_GND, OUTPUT);
  pinMode(RF_433_VCC, OUTPUT);
  pinMode(RF_433_DATA, INPUT);
  digitalWrite(RF_433_GND, LOW);
  digitalWrite(RF_433_VCC, HIGH);

  Serial.begin(250000);
  Serial.println("init");
}

void loop(){
// Signal Test
//  Serial.println(digitalRead(RF_433_DATA));
 if (digitalRead(RF_433_DATA) == 1){
    rf_433_count++;
  }else{
    if (rf_433_count != 0){
      if( rf_433_count > 1000){
        rf_433_count2++;
        Serial.println(rf_433_count);
      }
      rf_433_count = 0;
    }
  }
}
