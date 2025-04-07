# TeleHealthApp_Microservices
TeleHealthApp_Microservices - Microservice Pattern Assessment

Healthcare app- 
Create 3 microservices
- Patient
- Staff
- Appointment

All three microservices will have separate DBActions to be performed

- Public page for patient registration
- Patient registration will create two events
- Patient login credentials to be sent to patient
- Staff will be notified that patient has registeredBoth the above events are independent so avoid using rabbitMQ

***Register staff**
- Staff registration will notify staff on email regarding credentials 
- try using rabbitMQ

***Create appointment*** 
- Video appointment between Staff and Patient
- Create a feature for waiting room- Once a patient will join the video call,it will notify staff and vice Versa. 
- email/smsnotification