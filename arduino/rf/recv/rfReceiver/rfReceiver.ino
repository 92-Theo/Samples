#include <VirtualWire.h>



byte message[VW_MAX_MESSAGE_LEN]; // a buffer to store the incoming messages
byte messageLength = VW_MAX_MESSAGE_LEN; // the size of the message
 
const int RX_DIO_Pin = 11; // default 11
#define led 13

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  
  Serial.println("Ready to receive:");
  pinMode(led, OUTPUT);
  vw_set_rx_pin(RX_DIO_Pin); // Initialize RX pin
  vw_setup(2000); // Transfer speed : 2000 bits per sec
  vw_rx_start(); // Start the receiver
}

void loop() {
  // put your main code here, to run repeatedly:
//  Serial.println("Hello World");
//  delay(1000);
  // digitalWrite(led, HIGH);
  // digitalWrite(led, LOW);
  if (vw_get_message(message, &messageLength)) // Non-blocking
  {
    Serial.print("Received: ");
    for (int i = 0; i < messageLength; i++)
    {
      Serial.write(message[i]);
    }
    Serial.println();
  }
}
