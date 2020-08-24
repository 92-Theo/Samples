#define GND 2
#define VCC 5
#define DATA 3

void setup(){
  pinMode(GND, OUTPUT);
  pinMode(VCC, OUTPUT);
  pinMode(DATA, INPUT);
  digitalWrite(GND, LOW);
  digitalWrite(VCC, HIGH);

  Serial.begin(250000);

  Serial.println("init");
}


void loop(){

  if (digitalRead(DATA) == 1){
    Serial.println("SmartkeyOn");
  }
  delay(200);
//  Serial.println(digitalRead(DATA));
}
