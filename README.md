# LSCS
####2015 SENG 422 project.

The Land Surveyor Checklist System is a CRUD web application implemented using C# and ASP.NET MVC and WebAPI 2.0. It contains four main projects and four corresponding test projects (in a separate 'Tests' folder). The projects correspond to the system topology outlined in section 2.0 of our architectural design report.

In order for the project to function within a development environment, both the LSCS.API and LSCS.Web projects must be operational and running. LSCS.Web provides the browser with the necessary view template, as dictated by the controllers, and the ReactJS components poll the LSCS.API for whatever data is needed on the page.

All subsystems are functional and capable of dynamic communication and operations. Users can register new accounts, login, logout, assign managerial or surveyor roles, create checklists, edit checklists, remove checklists, and view checklists with live map and weather feeds for the relevant survey coordinates.

We were unable to meet our goals for API authentication or full support for account management, such as account recovery and modifications.

# Components

As stated above there are 4 main projects within the LSCS solution:
- LSCS.Api
- LSCS.Web
- LSCS.Repository
- LSCS.Models

Each of these components is discussed in more detail below.

## LSCS.Api

As the name indicates, this project contains the API. The API is responsible for handling all data transfers with regard to checklists. It provides endpoints to:
- retrieve a list of all checklists present in the system
- retrieve a single checklist specified by an ID
- create a checklist
- update a checklist
- delete a checklist

## LSCS.Web

The Web project contains the main web app. This project is where all the UI for the LSCS system is built. As discussed in our report, much of the front end uses React.JS to dynamically load data into the page as it is modified. The React components can be found in the `scripts/templates` directory in two `.jsx` files. 'Checklist.jsx' is responsible for populating the single checklist view while 'Checklists.jsx' handles the list of checklist.

The Web project also manages user accounts. It is supported by a SQL Server database instead of MongoDB, like the API. It provides the mechanisms to create new accounts, log in, log out, etc.

## LSCS.Models

The models project contains all the data models that are used by both the API and the Web project to transfer data.

## LSCS.Repository

The repository project contains code for configuring and handling communication with the database.

# User Perspectives

In accordance with the requirements specification, the Land Surveyor Checklist System operates with dynamic access control. Depending on the role of the user's account, the system will provide a variable user experience and workflow.

## Surveyor

Land Surveyors have the ability to login, logout and view the checklists in the system. They are unable to create new checklists, delete checklists, or to edit anything beyond checklist item status'. When a Land Surveyor accesses the edit view, the metadata of the checklist is removed from the user interface, and only the embedded map, weather frame, and checklist items are presented.

## Survey Manager

Survey Managers have the next level of system access. After logging in and being re-routed to the main page, Managers will be presented with an additional link to construct new checklists. The create view is a form page that allows the Manager to enter all the necessary metadata, from a file number to the survey location coordinates. Unlike the Land Surveyor's experience, this page is very similar to the Manager's edit page. When the Manager decides to edit a checklist, he is returned to the form page with all previously linked data filled in, including the active status of each checklist item. Any changes saved will be automatically updated for all the other users viewing the checklist. Lastly, Survey Managers have the ability to delete checklists. Doing so will once again result in a system wide refresh for all useres viewing the effected checklist.


## Administrator

Administrates 4 life.
