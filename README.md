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


I am sharing the postman collection below

-----------------------------


{
	"info": {
		"_postman_id": "79ec9166-e0c6-46f1-8ee2-8687a1e6ee1c",
		"name": "Guide",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "Contact Api",
			"item": [
				{
					"name": "Get Contact",
					"request": {
						"method": "GET",
						"header": [],
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Contact",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Contact"
							],
							"query": [
								{
									"key": "",
									"value": "",
									"disabled": true
								}
							]
						}
					},
					"response": []
				},
				{
					"name": "Get Report",
					"request": {
						"method": "GET",
						"header": [],
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Report/location?location=Devbase",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Report",
								"location"
							],
							"query": [
								{
									"key": "location",
									"value": "Devbase"
								}
							]
						}
					},
					"response": []
				},
				{
					"name": "Get Contact With Detaiil",
					"request": {
						"method": "GET",
						"header": [],
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Contact/communication",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Contact",
								"communication"
							]
						}
					},
					"response": []
				},
				{
					"name": "Create Communication",
					"request": {
						"method": "POST",
						"header": [],
						"body": {
							"mode": "raw",
							"raw": "{\r\n  \"contactId\": \"168e8608-af12-4a47-bcf7-1ea384580c01\",\r\n  \"phoneNumber\": \"0543000001\",\r\n  \"email\": \"ahmet.yardimci98@gmail.com\",\r\n  \"address\": \"samet test adres\",\r\n  \"location\": \"Ankara\"\r\n}",
							"options": {
								"raw": {
									"language": "json"
								}
							}
						},
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Communication",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Communication"
							]
						}
					},
					"response": []
				},
				{
					"name": "Update Contact",
					"request": {
						"method": "PUT",
						"header": [],
						"body": {
							"mode": "raw",
							"raw": "{\r\n  \"id\": \"168e8608-af12-4a47-bcf7-1ea384580c01\",\r\n  \"name\": \"Ahmet\",\r\n  \"lastName\": \"Yardimci\",\r\n  \"company\": \"Devbase\"\r\n}",
							"options": {
								"raw": {
									"language": "json"
								}
							}
						},
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Contact",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Contact"
							]
						}
					},
					"response": []
				},
				{
					"name": "Create Contact",
					"request": {
						"method": "POST",
						"header": [],
						"body": {
							"mode": "raw",
							"raw": "{\r\n  \"name\": \"test-user\",\r\n  \"lastName\": \"test-user\",\r\n  \"company\": \"test-company\"\r\n}",
							"options": {
								"raw": {
									"language": "json"
								}
							}
						},
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Contact",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Contact"
							]
						}
					},
					"response": []
				},
				{
					"name": "Get Contact With Id (Detail)",
					"request": {
						"method": "GET",
						"header": [],
						"url": {
							"raw": "https://localhost:5000/api/ContactApp/Contact/168e8608-af12-4a47-bcf7-1ea384580c01/communication",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ContactApp",
								"Contact",
								"168e8608-af12-4a47-bcf7-1ea384580c01",
								"communication"
							],
							"query": [
								{
									"key": "",
									"value": "",
									"disabled": true
								}
							]
						}
					},
					"response": []
				}
			]
		},
		{
			"name": "Report Api",
			"item": [
				{
					"name": "Create Report",
					"request": {
						"method": "POST",
						"header": [],
						"url": {
							"raw": "https://localhost:5000/api/ReportApp/Report?location=Devbase",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ReportApp",
								"Report"
							],
							"query": [
								{
									"key": "location",
									"value": "Devbase"
								}
							]
						}
					},
					"response": []
				},
				{
					"name": "Get Report",
					"request": {
						"method": "GET",
						"header": [],
						"url": {
							"raw": "https://localhost:5000/api/ReportApp/Report/?reportId=5e9b3b55-9555-4c3a-b7a7-30a574e78f1a",
							"protocol": "https",
							"host": [
								"localhost"
							],
							"port": "5000",
							"path": [
								"api",
								"ReportApp",
								"Report",
								""
							],
							"query": [
								{
									"key": "reportId",
									"value": "5e9b3b55-9555-4c3a-b7a7-30a574e78f1a"
								}
							]
						}
					},
					"response": []
				}
			]
		}
	]
}



-----------------------------
