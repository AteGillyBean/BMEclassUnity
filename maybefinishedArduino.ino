//TOF
#include "Adafruit_VL53L0X.h"
Adafruit_VL53L0X lox = Adafruit_VL53L0X();

//LED
int redPin = 9;

//VIBRO
int vibroPin = 4;
int inputVal;

void setup() {
  Serial.begin(115200);

  //TOF
  while (! Serial) {
    delay(1);
  }
  if (!lox.begin()) {

    while(1);
  }

  //LED
  pinMode(redPin, OUTPUT);

  //VIBRO
  pinMode(vibroPin, OUTPUT);
}


void loop() 
{
  //TOF
  VL53L0X_RangingMeasurementData_t measure;
    
  lox.rangingTest(&measure, false); // pass in 'true' to get debug data printout!

  if (measure.RangeStatus != 4) 
  {
    Serial.println(String(measure.RangeMilliMeter));
  } 
  else 
  {
  }
  delay(100);

  //LED & Vibro
  while (Serial.available())
  {
    inputVal = Serial.read();

    if (inputVal == '1') //collides with obstacle
    {
      digitalWrite(redPin, HIGH); //red on
      digitalWrite(vibroPin, HIGH); //motor on
    }

    if (inputVal == '0')
    {
      digitalWrite(redPin, LOW); //red on
      digitalWrite(vibroPin, LOW); //motor on
    }
  }
}


