SAMPLE DATA

//Login Request

{
  "username": "Approval",
  "password": "General@123",
  "role": "Approval"
}

//Login Request

{
  "statusCode": "200",
  "responseCode": "00",
  "message": "Record was successfully retrieved",
  "data": {
    "userRole": "Approval",
    "username": "Approval",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiQXBwcm92YWwiLCJ1bmlxdWVfbmFtZSI6IkFwcHJvdmFsIiwibmJmIjoxNjk5MzA1ODkyLCJleHAiOjE2OTkzOTIyOTIsImlhdCI6MTY5OTMwNTg5Mn0.4WZmY28aTGx9BITqpu0I-4ShUJCnAIFcX7NXzn-LL1U",
    "refreshToken": "mGRY4N/mQawn1/uvd+7HlQ6iF0MyeH29Ic51zB5BI0U=",
    "refreshTokenExpiryTime": "2023-11-06T23:24:52.8456746+01:00"
  }
}


//Refresh Token Request

{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiQXBwcm92YWwiLCJ1bmlxdWVfbmFtZSI6IkFwcHJvdmFsIiwibmJmIjoxNjk5MzA1ODkyLCJleHAiOjE2OTkzOTIyOTIsImlhdCI6MTY5OTMwNTg5Mn0.4WZmY28aTGx9BITqpu0I-4ShUJCnAIFcX7NXzn-LL1U",
  "refreshToken": "mGRY4N/mQawn1/uvd+7HlQ6iF0MyeH29Ic51zB5BI0U="
}

//Refresh Token Response

{
  "statusCode": "200",
  "responseCode": "00",
  "message": "Successful",
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBcHByb3ZhbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBcHByb3ZhbCIsIm5iZiI6MTY5OTMwNTg5MiwiZXhwIjoxNjk5MzA5NzI1LCJpYXQiOjE2OTkzMDU4OTJ9.5_Otly_tBny3hR7SUCSOM4zEgOFrjWbusGBgwjfGRyw",
    "refreshToken": "vqqcTj/h21LlPpun458crAIJ2EN2eF9YHghixOs06fs="
  }
}

//policy holder application responseCode

{
  "statusCode": "200",
  "responseCode": "00",
  "message": "successful",
  "data": {
    "nationalIDNumber": 1,
    "name": "Lucy",
    "surname": "Frank",
    "dateofBirth": "1987-09-09T00:00:00",
    "policyNumber": "7",
    "claimID": 7,
    "expenses": "Wedding",
    "expenseAmount": 12000,
    "expenseDate": "2023-04-07T00:00:00"
  }
}

//All Policy Holder Claims Response

{
  "statusCode": "200",
  "responseCode": "00",
  "message": "Successful",
  "data": [
    {
      "id": 1,
      "nationalIDNumber": 1,
      "name": "Sheriff",
      "surname": "Ebelebe",
      "claimStatus": "Approved",
      "dateofBirth": "1960-11-06T00:00:00Z",
      "policyNumber": "1",
      "claimID": 1,
      "expenses": "Transportation",
      "expenseAmount": 2000,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 1,
      "nationalIDNumber": 1,
      "name": "Lucy",
      "surname": "Frank",
      "claimStatus": "Approved",
      "dateofBirth": "1987-09-09T00:00:00Z",
      "policyNumber": "7",
      "claimID": 1,
      "expenses": "Transportation",
      "expenseAmount": 2000,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 1,
      "nationalIDNumber": 1,
      "name": "Sheriff",
      "surname": "Ebelebe",
      "claimStatus": "Approved",
      "dateofBirth": "1960-11-06T00:00:00Z",
      "policyNumber": "1",
      "claimID": 1,
      "expenses": "Transportation",
      "expenseAmount": 2000,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 1,
      "nationalIDNumber": 1,
      "name": "Lucy",
      "surname": "Frank",
      "claimStatus": "Approved",
      "dateofBirth": "1987-09-09T00:00:00Z",
      "policyNumber": "7",
      "claimID": 1,
      "expenses": "Transportation",
      "expenseAmount": 2000,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 2,
      "nationalIDNumber": 2,
      "name": "Moses",
      "surname": "Joy",
      "claimStatus": "In-Review",
      "dateofBirth": "1961-11-06T00:00:00Z",
      "policyNumber": "2",
      "claimID": 2,
      "expenses": "Transportation",
      "expenseAmount": 2100,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 3,
      "nationalIDNumber": 3,
      "name": "Paul",
      "surname": "Ola",
      "claimStatus": "In-Review",
      "dateofBirth": "1962-11-06T00:00:00Z",
      "policyNumber": "3",
      "claimID": 3,
      "expenses": "Transportation",
      "expenseAmount": 2200,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 4,
      "nationalIDNumber": 4,
      "name": "Odia",
      "surname": "Okafor",
      "claimStatus": "Submitted",
      "dateofBirth": "1963-11-06T00:00:00Z",
      "policyNumber": "4",
      "claimID": 4,
      "expenses": "Transportation",
      "expenseAmount": 2300,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 5,
      "nationalIDNumber": 5,
      "name": "Uche",
      "surname": "James",
      "claimStatus": "Submitted",
      "dateofBirth": "1964-11-06T00:00:00Z",
      "policyNumber": "5",
      "claimID": 5,
      "expenses": "Transportation",
      "expenseAmount": 2400,
      "expenseDate": "2023-11-06T00:00:00Z"
    },
    {
      "id": 6,
      "nationalIDNumber": 6,
      "name": "Chuks",
      "surname": "Oma",
      "claimStatus": "Submitted",
      "dateofBirth": "1980-09-09T00:00:00Z",
      "policyNumber": "6",
      "claimID": 6,
      "expenses": "Feeding",
      "expenseAmount": 3000,
      "expenseDate": "2023-09-09T00:00:00Z"
    },
    {
      "id": 7,
      "nationalIDNumber": 1,
      "name": "Sheriff",
      "surname": "Ebelebe",
      "claimStatus": "Submitted",
      "dateofBirth": "1960-11-06T00:00:00Z",
      "policyNumber": "1",
      "claimID": 7,
      "expenses": "Wedding",
      "expenseAmount": 12000,
      "expenseDate": "2023-04-07T00:00:00Z"
    }
  ]
}
