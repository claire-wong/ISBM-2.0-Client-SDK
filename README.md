# ISBM-2.0-Client-SDK

Open Industrial Interoperability Ecosystem (OIIE) a vendor-neutral, interoperable ecosystem to tackle industry-wide data silo challenges. It enables a cluster of IoT/IoE devices and processes to communicate in an interoperable and scalable manner. This Software Development Toolkit is designed to assist anyone interested in trying out the Open Industrial Interoperability Ecosystem (OIIE) with easy to follow examples. 

### Contents
  
   1. [Objectives](#Objectives)
   2. [ISBM Client Adapters Architecture](#ISBM-Client-Adapters-Architecture-Diagram)
   3. [Project Information](#Project-Information)
   4. [Before Running the Program](#Before-Running-the-Program)
   5. [Useful Links](#Useful-Links)
   6. [Quick Reference](#Quick-Reference)

### Objectives

Since OIIE involves multiple industry standards at different levels of the technology stack, it is helpful to have a developer friendly OIIE programming interfaces. This SDK includes sample C# code projects and three flavors of ISBM 2.0 Client Adapters (RapidRedPanda.ISBM.ClientAdapter), .Net Core 3.1, .NET Standard 2.0, and .NET 6. They support a wide range of .Net implementations and OS or hardware platforms; see details in the ISBM Client Adapter Architecture Diagram. By using the adapter, you can deliver and receive CCOM messages (Common Conceptual Object Model) through ISBM services (ISA-95 Message Service Model) with just a few lines of code! It reduces the learning curve, allowing you to explore OIIE without diving into the technical details of the standards

The NuGet package [RapidRedPanda.ISBM.ClientAdapter](https://www.nuget.org/packages/RapidRedPanda.ISBM.ClientAdapter/#readme-body-tab) package is designed to handle all the details of ISBM implementations for communication with ISBM servers. The ISBM interface will be accessible through object classes that developers should find user-friendly and easy to use. This will cut down the learning curve of building ISBM-compliant devices or applications.

      
### ISBM Client Adapters Architecture Diagram

![image](/Documents/Images/Architecture_Diagram1.jpg)

### ISBM Message Patterns
ISBM 2.0 (ISA-95 Message Service Model) defines two message bus models: the publish-subscribe (pub/sub) model and the request-response model. In the following section, a brief overview of the two message bus models will be provided.

### Project Information

### Use Cases

#### 1. Example of using Publication-Subscription model:  [Smart Agriculture Monitoring System](Documents/Use_Cases/Smart-Agriculture-Monitoring-System.md) 
#### 2. Example of using Request-Response model:  [Fleet Management System for Logistics](Documents/Use_Cases/Fleet_Management.md)
#### 3. Example of using both Publication-Subscription and Request-Response models:  [Flood Management System](Documents/Use_Cases/Flood-Management.md)
 

