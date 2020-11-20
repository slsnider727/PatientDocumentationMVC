## Patient Documentation MVC

I developed this patient documentation MVC during my last 4 weeks at Eleven Fifty Academy's software development bootcamp. This program is designed for use in small healthcare offices or multi-clinic networks of any variety. Through the healthcare professional portal, patient-access staff can manage patient information and schedules, and healthcare providers can view patient information, schedules, and document treatments with a universal note creation service.

#### Prerequisites
To run this program locally on your computer, you will need:
- Visual Studio Community
- A web browser

#### Initial Set Up
- Clone to your local repository and open in VS Community.
- You will need to set up a connection string. Create a new, empty config file named "ConnectionStrings.config" and add a connection string here for Web.config to access.
- Open the Package Manager Console. Select PatientDocumentation.Data as the default project and run "update-database" in the command line to seed the database. This will create an Admin user with UserName "admin@mvc.com" and password "Pw123!".

#### Using the Program
- When you first run the program, you'll see that there is some information you can access before logging in - namely, information about Clinics and Providers.
-	Admins have full functional capabilities for all components and are the only ones who can create/manage Clinics, Providers, and manage roles for other users. They can access all functions from the drop-down menu. Use the default Admin login to enter your Clinics and Providers into the database and tie your Providers' UserIds to their listing information.
-	Users with the Receptionist role can Create/Manage Patient information and Appointments.
- Users with the Provider role can Manage Patient information, have their own Schedule view, and Create/Manage treatment notes for their appointments.
- A Patient user role currently exists but there is no function as yet for this role. In future updates, Patients will be able to see their upcoming appointments.

#### Author
 Sabra Snider [/slsnider727](https://github.com/slsnider727)

#### Resources Used

[Asp.Net Identity and User Manager, Role-Based Authorization (1:56:26)](https://www.youtube.com/watch?v=zWFoZb6EiwU)

[Inspo for Role Manager](https://www.dotnetfunda.com/articles/show/3240/simple-role-manager-in-aspnet-mvc-5)

[Role-Based Authorization](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-3.1)

[Display controller's param in view](https://stackoverflow.com/questions/6514292/c-sharp-razor-url-parameter-from-view) 

[Assign Default Role to User](https://stackoverflow.com/questions/27819405/automatically-assign-default-role) 

[Creating Large Text Area Editor](http://techfunda.com/howto/408/textarea-with-html-editorfor#:~:text=To%20bring%20TextArea%20with%20%40Html,particular%20property%20of%20the%20model.&text=If%20we%20want%20the%20width,css%20class.)

[DateTime Documentation](https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1)

