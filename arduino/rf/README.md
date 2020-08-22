아두이노 RF 125Khz, 315Mhz, 433Mhz 샘플

ref : https://deneb21.tistory.com/546

Sender code
#include <VirtualWire.h>
 
const int TX_DIO_Pin = 12; // default 12
 
 
void setup()
{
  vw_set_tx_pin(TX_DIO_Pin); // Initialize TX pin
  vw_setup(2000); // Transfer speed : 2000 bits per sec
}
 
void loop()
{
  send("DOIYYOURSELF");
  delay(1000);
}
 
void send (char *message)
{
  vw_send((uint8_t *)message, strlen(message));
  vw_wait_tx(); // Wait until the whole message is gone
}
Col


Receiver code
#include <VirtualWire.h>
 
byte message[VW_MAX_MESSAGE_LEN]; // a buffer to store the incoming messages
byte messageLength = VW_MAX_MESSAGE_LEN; // the size of the message
 
const int RX_DIO_Pin = 11; // default 11
 
void setup()
{
  Serial.begin(9600);
  Serial.println("Ready to receive:");
  vw_set_rx_pin(RX_DIO_Pin); // Initialize RX pin
  vw_setup(2000); // Transfer speed : 2000 bits per sec
  vw_rx_start(); // Start the receiver
}
 
void loop()
{
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