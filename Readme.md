# Backend Web API  

This is a backend Web API built using **C#** and **PostgreSQL**, containerized with **Docker** for streamlined deployment and scalability.  

## Prerequisites  
Before running this application, ensure the following are installed and set up on your system:  
- [.NET SDK](https://dotnet.microsoft.com/download)  
- [Docker](https://www.docker.com/get-started)  
- PostgreSQL client (optional, for manual database checks)  

## Getting Started  

Follow these steps to run the application:  

1. **Clone the Repository**  
   Clone this repository to your local machine:  
   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```  

2. **Restore Packages**  
   Restore the required .NET dependencies:  
   ```bash
   dotnet restore
   ```  

3. **Set Up Docker**  
   - Ensure Docker is installed and running on your system.  
   - If Docker is not ready, refer to the [official Docker documentation](https://docs.docker.com/get-started/).  

4. **Configure Docker Compose**  
   Update the `docker-compose.yml` file to set the desired application port.  
   For example, to use port `5000`, modify the `ports` section as follows:  
   ```yaml
   ports:
     - "5000:5000"
   ```  

5. **Build and Start Containers**  
   Navigate to the root of the cloned repository and run the following command to build and start the containers:  
   ```bash
   docker-compose up -d
   ```  

6. **Verify the Containers**  
   Check if the containers are up and running:  
   ```bash
   docker ps
   ```  

7. **Access the Application**  
   Open your browser and navigate to the application URL using the configured port:  
   ```plaintext
   http://localhost:<port>
   ```  

## Additional Notes  
- Set the application port to `5000`, but you can modify it in the `docker-compose.yml` file as needed.  
- Below is a screenshot of the configuration to change:  
  ![Docker Compose Configuration](<Screenshot from 2025-01-19 20-17-52-1.png>)  

## Troubleshooting  
If you encounter any issues, ensure:  
- Docker is running properly.  
- The specified port is not in use by other applications.  
- All dependencies are restored using `dotnet restore`.  

Feel free to contribute by submitting issues or pull requests!
