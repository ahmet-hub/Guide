# Guide

Step 1 : Create Postgresql Db localhost port 5432 and update appsettings.json for Connection strings
          Example : Server=localhost;Database=Guide;Port=5432;User Id=postgres;Password=123;
      
Step 2 : Create kafka and update json file 
          "KafkaOptions": {
              "GroupId": "guide-kafka-group-report",
              "Endpoint": "localhost:9092",
              "ReportTopic": "ReportTopic"
           }
           
Step 3 : Update database Report api microservice and Report api microservice

Postman Collection : https://www.getpostman.com/collections/e5ae275b993fa06bd828
