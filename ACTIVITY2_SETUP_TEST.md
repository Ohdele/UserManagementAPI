"# Activity 2:


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