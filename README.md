"# Project Title"
User Management API

=============
TASK 1:
User Management API Project Documentation
=============

#### **Overview**
The User Management API project for TechHive Solutions allows the HR and IT departments to efficiently create, update, retrieve, and delete user records. This documentation outlines the steps to set up, develop, and test the API using Microsoft Copilot.

#### **Step 1: Review the Scenario**
Understand the intent and requirements for the User Management API project. Your task is to build core functionality enabling user record management, utilizing Microsoft Copilot to assist in scaffolding, enhancing, and testing the code.


### Step 2: Set Up the Project

1. **Create a New Project:**
   - Open Visual Studio Code.
   - Open a terminal and navigate to your desired directory.
   - Run: `dotnet new webapi -n UserManagementAPI`
   - Open the new project: `cd UserManagementAPI && code .`

2. **Scaffold Project Setup:**
   - Use Microsoft Copilot to add necessary boilerplate code to `Program.cs`.

This step ensures your project is set up and ready for further development.


Step 3: Generate API endpoints
Then use Copilot to help you generate API endpoints.

Use Copilot to generate CRUD endpoints for managing users:

GET: Retrieve a list of users or a specific user by ID.

POST: Add a new user.

PUT: Update an existing user's details.

DELETE: Remove a user by ID.


**Postman Collection Setup for User Management API Testing**

**Important Note:** The reviewer *must* restart the application (`dotnet run`) before each full test run to ensure consistent results. This is because user data is stored in memory and is cleared on restart.

**Collection:** Create a new Collection in Postman named "User Management API".

**Requests (Add these requests within the "User Management API" Collection):**

**1. GET all users (Empty Array):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body: `[]`

**2. POST a new user (John Doe):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "John Doe",
        "email": "john.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}` (The `id` might be different on subsequent runs after restarts)

**3. GET the created user by ID (John Doe):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User/1` (Use the `id` from the previous POST response)

*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}`

**4. POST another user (Jane Doe):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "Jane Doe",
        "email": "jane.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 2, "name": "Jane Doe", "email": "jane.doe@example.com"}`

**5. GET all users (Both Users):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `[{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}, {"id": 2, "name": "Jane Doe", "email": "jane.doe@example.com"}]`

**6. PUT update an existing user (John Doe):**

*   **Request Type:** PUT
*   **URL:** `http://localhost:5176/User/1`
*   **Body (raw JSON):**

    ```json
    {
        "name": "Updated John",
        "email": "updated.john@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 204 No Content (No response body)

**7. GET the updated user (Updated John):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User/1`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `{"id": 1, "name": "Updated John", "email": "updated.john@example.com"}`

**8. DELETE a user (John Doe):**

*   **Request Type:** DELETE
*   **URL:** `http://localhost:5176/User/1`
*   **Expected Output:**
    *   Status Code: 204 No Content (No response body)

**9. GET all users after delete (Jane Doe):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `[{"id": 2, "name": "Jane Doe", "email": "jane.doe@example.com"}]`




=============
TASK 2:
Debugging API Code with Copilot
=============

In this activity, I used Copilot to debug the code I started for my API project. This project gave me practice reviewing code, debugging, and implementing fixes. I used Copilot to discover issues and suggest changes to improve my code.

This is the second of three activities in which I will develop and code a back-end API project. The final output will be a working API project that demonstrates my understanding of back-end development.

STEP 1:
### Step 1: Review the Scenario

After deploying the initial version of the User Management API, TechHive Solutions reported several bugs:

- Users were being added without proper validation.
- Errors occurred when retrieving non-existent users.
- The API occasionally crashed due to unhandled exceptions.

My task is to debug the API using Microsoft Copilot, ensuring it works reliably and meets the company’s requirements.


### STEP 2: IDENTIFY BUGS

I used Microsoft Copilot to analyze the existing codebase and identified the following issues:
- Missing validation for user input fields (e.g., empty names or invalid emails) in `POST` and `PUT` requests.
- Lack of error handling for failed database lookups, such as non-existent user IDs in `GET` requests.

These issues were noted for fixing in the next step.


### Step 3: Fix Bugs with Copilot

Using Microsoft Copilot, I fixed the identified issues by:
- Adding validation to ensure only valid user data is processed in `POST` and `PUT` requests.
- Implementing error handling by returning appropriate responses for failed database lookups, such as `NotFound` for non-existent users.
- Optimizing the logic for CRUD operations to improve performance and maintain efficiency.

These fixes have improved the reliability and functionality of the User Management API.


### Step 4: Test and Validate Fixes

**Postman Collection Setup for User Management API Testing (Activity 2 - Validation Tests)**

**Important Note for Reviewer:** This setup is for *Activity 2 only*. Before starting these tests, please ensure you have:

1.  Completed the testing for Activity 1.
2.  **Restarted the application (`dotnet run`).** This is crucial to ensure a clean testing environment for Activity 2 and to clear any data that might have been created during Activity 1 testing.

**Collection:** Create a new Collection in Postman named "User Management API".

**Requests:**

**(Activity 2 - Validation Tests)**

**1. POST a new user (John Doe - Setup for PUT tests):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "John Doe",
        "email": "john.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}`

**2. PUT update an existing user (Missing Name - Invalid):**

*   **Request Type:** PUT
*   **URL:** `http://localhost:5176/User/1`
*   **Body (raw JSON):**

    ```json
    {
        "email": "updated.john@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 400 Bad Request
    *   Response Body: "Name is required."

**3. POST a new user (John Doe - Setup for PUT tests - Repeat):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "John Doe",
        "email": "john.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 2, "name": "John Doe", "email": "john.doe@example.com"}`

**4. PUT update an existing user (Missing Email - Invalid):**

*   **Request Type:** PUT
*   **URL:** `http://localhost:5176/User/2`
*   **Body (raw JSON):**

    ```json
    {
        "name": "Updated John"
    }
    ```

*   **Expected Output:**
    *   Status Code: 400 Bad Request
    *   Response Body: "Email is required."

**5. POST a new user (John Doe - Setup for PUT tests - Repeat):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "John Doe",
        "email": "john.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 3, "name": "John Doe", "email": "john.doe@example.com"}`

**6. PUT update an existing user (Invalid Email Format - Invalid):**

*   **Request Type:** PUT
*   **URL:** `http://localhost:5176/User/3`
*   **Body (raw JSON):**

    ```json
    {
        "name": "Updated John",
        "email": "invalid-email"
    }
    ```

*   **Expected Output:**
    *   Status Code: 400 Bad Request




=================
TASK 3:
Implementing and Managing Middleware with Copilot
=================

Generative AI tools like Microsoft Copilot can help implement and manage middleware in back-end projects.

In this task, I will use Copilot to create middleware for logging, authentication, and error handling and configure the middleware pipeline. This project gave me practice working with middleware, from implementation to management. Copilot helped with every step of this process.

In this last task, I developed and coded a back-end API project. The final output is a working API project to demonstrate my understanding of back-end development.


### STEP 1: REVIEW THE SCENARIO

To comply with corporate policies, TechHive Solutions requires middleware in the User Management API to:
- Log all incoming requests and outgoing responses for auditing purposes.
- Enforce standardized error handling across all endpoints.
- Secure API endpoints using token-based authentication.

My task is to implement these middleware components using Microsoft Copilot and configure the middleware pipeline for optimal performance.


### Step 2: Implement Logging Middleware

Using Copilot, I added middleware to log HTTP requests and responses in my project. This middleware logs:
- HTTP method (e.g., GET, POST)
- Request path
- Response status code

The middleware is implemented and configured in the `program.cs` file.


### Step 3: Implement Error-Handling Middleware

Using Copilot, I created middleware to handle errors by:
- Catching unhandled exceptions.
- Returning consistent error responses in JSON format (e.g., { "error": "Internal server error." }).

The middleware is implemented and configured in the `program.cs` file.


### Step 4: Implement Authentication Middleware

Using Copilot, I created middleware to handle authentication by:
- Validating tokens from incoming requests.
- Allowing access only to users with valid tokens.
- Returning a 401 Unauthorized response for invalid tokens.

The middleware is implemented and configured in the `program.cs` file.


### Step 5: Configure the Middleware Pipeline

To ensure the middleware is configured correctly, I have arranged it in the following order in the `program.cs` file:
1. Error-handling middleware first.
2. Authentication middleware next.
3. Logging middleware last.

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