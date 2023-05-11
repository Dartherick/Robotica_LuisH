int R,G,B;
String Colors;
String StringRead;

void setup() {
  Serial.begin(9600);
}

void loop() {
  GetColorValues();
}

void GetColorValues(){

  while (Serial.available())
  {
    StringRead = Serial.read();
    if (StringRead.length() >0) 
    {
      Serial.println(StringRead); //see what was received
      int i1 = Colors.indexOf(',');
      int i2 = Colors.indexOf(',', i1+1);
      Serial.println(i1);
      Serial.println(i2);

      R = Colors.substring(0, i1).toInt();
      G = Colors.substring(i1 + 1, i2).toInt();
      B = Colors.substring(i2 + 1).toInt();

      Serial.println("Valores obtenidos son:");
      Serial.println(R);
      Serial.println(G);
      Serial.println(B);
    }
  }
}