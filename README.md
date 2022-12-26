# SVT-Robotics
SVT Robotics - .NET Core Take Home Recruiting Assessment

## Local Development (Mac OS / Ubuntu)

 - .NET version 6.0.403
 
 ### Application Level Packages
 
 **Project:**

- System.Net.Http version 4.3.4
- Microsoft.AspNet.WebApi.Client version 5.2.9
- Newtonsoft.Json version 13.0.1

**Tests:**

- Microsoft.NET.Test.Sdk version 17.1.0
- xunit version 2.4.1
- xunit.runner.visualstudio version 2.4.3

### Running the Application

**Project:**

Run these steps in the project directory i.e. TestProject

- dotnet build (To check if the build is successfull)
- dotnet run (To run the server)

**Tests:**

Run this in the test directory i.e. TestProject.Tests and the server should be up and running for the tests to be successfull

- dotnet test

## Api Endpoint

**Positive:**
Method: `POST`
url:  `https://localhost:5000/api/robots/closest`
Parameters:
```
{
    loadId: 231, //Arbitrary ID of the load which needs to be moved.
    x: 5, //Current x coordinate of the load which needs to be moved.
    y: 3 //Current y coordinate of the load which needs to be moved.
}
```

It should respond with a payload of this type:

```
{
    robotId: 58,
    distanceToGoal: 49.9, //Indicates how far the robot is from the load which needs to be moved.
    batteryLevel: 30 //Indicates current battery level of the robot.
}
```
**Negative:**
If fed with a wrong payload it should return an error statement.

Method: `POST`
url:  `https://localhost:5000/api/robots/closest`
Parameters:
```
{
    x: 5, //Current x coordinate of the load which needs to be moved.
    y: 3 //Current y coordinate of the load which needs to be moved.
}
```

It should respond with a string saying:
``` Correct Payload is not being fed ```

## What would I do next?

- Further improvise the current endpoint by taking the battery level of the robot for every kind of distance, making a more accurate algorithm.
- Configure a databse and add all the request and response payload in the database after DeSerealization, and then using that data to improve the performance of the algorithm.
- Try to devise faster solutions in case of bulk data.
