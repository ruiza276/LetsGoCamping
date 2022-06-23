# LetsGoCamping!
## Lets make a reservation here!
<br /> This is Web API written in .NET Core 5.0.0. It has a GET endpoint that accepts a JSON payload of:
```
{
  "search": {
    "startDate": "<string>",
    "endDate": "<string>"
  },
  "campsites": 
  [
    {
        "id": <int>,
        "name": "<string>"
        } 
    ],
  "reservations": 
  [
    {
        "campsiteId": <int>, 
        "startDate": "<string>", 
        "endDate": "<string>"
        }
    ]
}
```
<br /> It then uses an algorithm to calculate a viable campsite based on the existing reservations of the campsite and the search dates given ensuring there is no 1 day gaps between reservations.

And outputs a response JSON payload of:
```
{
  [ "<string>" ]
}
```
- Please Note: That the data does not persist anywhere at the moment
<br />

## To Run In Visual Studio Code Ubuntu Linux/Windows 
1. Make sure .NET Core SDK 5.0.0 is installed and targeted by machine. 
2. Clone Repo.
3. To start LetsGoCamping. Hit F5/Run --> Start Debugging in VS Code
4. From there use a tool like Postman to send a GET JSON payload in the format above to https://localhost:5001/CampingReservation
5. Response should be a JSON Premium payload in the format above. or you can use the cuRL below! :D

```
curl --location --request GET 'https://localhost:5001/CampingReservation' \
--header 'Content-Type: application/json' \
--data-raw '{
    "search": {
        "startDate": "2018-06-04",
        "endDate": "2018-06-06"
    },
    "campsites": [
        {
            "id": 1,
            "name": "Cozy Cabin"
        },
        {
            "id": 2,
            "name": "Comfy Cabin"
        },
        {
            "id": 3,
            "name": "Rustic Cabin"
        },
        {
            "id": 4,
            "name": "Rickety Cabin"
        },
        {
            "id": 5,
            "name": "Cabin in the Woods"
        }
    ],
    "reservations": [
        {
            "campsiteId": 1,
            "startDate": "2018-06-01",
            "endDate": "2018-06-03"
        },
        {
            "campsiteId": 1,
            "startDate": "2018-06-08",
            "endDate": "2018-06-10"
        },
        {
            "campsiteId": 2,
            "startDate": "2018-06-01",
            "endDate": "2018-06-01"
        },
        {
            "campsiteId": 2,
            "startDate": "2018-06-02",
            "endDate": "2018-06-03"
        },
        {
            "campsiteId": 2,
            "startDate": "2018-06-07",
            "endDate": "2018-06-09"
        },
        {
            "campsiteId": 3,
            "startDate": "2018-06-01",
            "endDate": "2018-06-02"
        },
        {
            "campsiteId": 3,
            "startDate": "2018-06-08",
            "endDate": "2018-06-09"
        },
        {
            "campsiteId": 4,
            "startDate": "2018-06-07",
            "endDate": "2018-06-10"
        }
    ]
}'
```
<br />
SideNote: NUnit Framkework Unit Tests are avaliable to run within the tests folder :D
<br /> 

## Run from LetsGoCamping.zip for Windows (TBA)

# Next Steps
1. Would like to use at the very least a in DBContext (beginnings of a memory allocated DB in code) to persist data.
2. Implement DELETE, PUT and POST for all data resources
3. Implement a logger in the API, I used Nlogger in a previous role and was very handy when it came to debugging
4. Fix that gap logic, there’s  probably a better way to do it