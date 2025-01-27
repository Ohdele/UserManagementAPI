"# Activity 3:

**Postman Collection Setup for User Management API Testing**

**Important Note:** The reviewer *must* restart the application (`dotnet run`) before each full test run to ensure consistent results. This is because user data is stored in memory and is cleared on restart.

**Collection:** Create a new Collection in Postman named "User Management API".

**Requests (Add these requests within the "User Management API" Collection):**


# FULL POSTMAN SETUP TO TEST FUNCTIONALITY

## 1. TEST CASE: VALID TOKEN (Authorized Request)
Request Type: GET
URL: http://localhost:5176/User
Headers:
  Key: Authorization
  Value: Bearer test-token


Expected Output:
  - Status Code: 200 OK
  - Response Body: `[]` (Empty array if no users are added yet)


---

## 2. TEST CASE: INVALID TOKEN (Unauthorized Request)
Request Type: GET
URL: http://localhost:5176/User
Headers:
  Key: Authorization
  Value: Bearer invalid-token


Expected Output:
  - Status Code: 401 Unauthorized
  - Response Body: Unauthorized


---

## 3. TEST CASE: NO TOKEN (Unauthorized Request)
Request Type: GET
URL: http://localhost:5176/User
Headers:
  (Do not include the Authorization header)


Expected Output:
  - Status Code: 401 Unauthorized
  - Response Body: Unauthorized


---

## 4. TEST CASE: VALID TOKEN WITH USER CREATION (Authorized Request)
Request Type: POST
URL: http://localhost:5176/User
Headers:
  Key: Authorization
  Value: Bearer test-token
  Key: Content-Type
  Value: application/json
Body (raw JSON):
{
  "name": "John Doe",
  "email": "john.doe@example.com"
}

Click Send

Expected Output:
  - Status Code: 201 Created
  - Response Body:
    {
      "id": 1,
      "name": "John Doe",
      "email": "john.doe@example.com"
    }


---


## 5. TEST CASE: INVALID ENDPOINT (404 Error)
Request Type: GET
URL: http://localhost:5176/NonExistentEndpoint
Headers:
  Key: Authorization
  Value: Bearer test-token

Expected Output:
  - Status Code: 404 Not Found
  - Response Body: Not Found
