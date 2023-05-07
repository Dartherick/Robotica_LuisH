int R,G,B;
String Colors;

void setup() {
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
}

void GetColorValues(){
  int i1 = Colors.indexOf(',');
  int i2 = Colors.indexOf(',', i1+1);
  Serial.println(i1);
  Serial.println(i2);

  R = Colors.substring(0, i1).toInt();
  G = Colors.substring(i1 + 1, i2).toInt();
  B = Colors.substring(i2 + 1).toInt();

  Serial.println(R);
  Serial.println(G);
  Serial.println(B);
}