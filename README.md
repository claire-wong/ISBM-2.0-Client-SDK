# ISBM-2.0-Client-SDK

Open Industrial Interoperability Ecosystem (OIIE) a vendor-neutral, interoperable ecosystem to tackle industry-wide data silo challenges. It enables a cluster of IoT/IoE devices and processes to communicate in an interoperable and scalable manner. This Software Development Toolkit is designed to assist anyone interested in trying out the Open Industrial Interoperability Ecosystem (OIIE) with easy to follow examples. 

## Contents
  
   1. [Objectives](#Objectives)
   2. [ISBM Client Adapters Architecture](#ISBM-Client-Adapters-Architecture-Diagram)
   3. [Project Information](#Project-Information)
   4. [Before Running the Program](#Before-Running-the-Program)
   5. [Useful Links](#Useful-Links)
   6. [Quick Reference](#Quick-Reference)

## Objectives

Since OIIE involves multiple industry standards at different levels of the technology stack, it is helpful to have a developer friendly OIIE programming interfaces. This SDK includes sample C# code projects and three flavors of ISBM 2.0 Client Adapters (RapidRedPanda.ISBM.ClientAdapter), .Net Core 3.1, .NET Standard 2.0, and .NET 6. They support a wide range of .Net implementations and OS or hardware platforms; see details in the ISBM Client Adapter Architecture Diagram. By using the adapter, you can deliver and receive CCOM messages (Common Conceptual Object Model) through ISBM services (ISA-95 Message Service Model) with just a few lines of code! It reduces the learning curve, allowing you to explore OIIE without diving into the technical details of the standards

The NuGet package [RapidRedPanda.ISBM.ClientAdapter](https://www.nuget.org/packages/RapidRedPanda.ISBM.ClientAdapter/#readme-body-tab) package is designed to handle all the details of ISBM implementations for communication with ISBM servers. The ISBM interface will be accessible through object classes that developers should find user-friendly and easy to use. This will cut down the learning curve of building ISBM-compliant devices or applications.

      
#### ISBM Client Adapters Architecture Diagram

![image](/Documents/Images/Architecture_Diagram1.jpg)

## ISBM Message Models

A message bus is a communication platform that allows different devices or processes to communicate with each other. It serves as a centralized hub where messages are sent and received by various systems, enabling asynchronous and decoupled communication. This architecture facilitates scalability, flexibility, and interoperability within complex cluster. ISBM 2.0 (ISA-95 Message Service Model) defines two message bus models: the publication-subscribe (pub/sub) model and the request-response model.

### Publication-Subscription model

In this model, publishers send messages to a central message broker (ISBM Service Provider), and subscribers receive messages based on their interests or subscriptions to specific topics or channels.

#### Breakdown of the key components and concepts of the publish-subscribe message bus model

#### Provider Applications:

Provider applications are devices or systems that generate and send messages to the ISBM aervice provider. They produce messages related to specific topics or events without knowing who will receive them.

#### Consumer Applications:

Consumer applications are devices or systems that receive messages from the the ISBM aervice provider based on their subscriptions to specific topics and channels. They express interest in receiving messages about particular topics or events.

#### ISBM Service Provider:

The ISBM service provider acts as an intermediary between provider applications and consumer applications. It receives messages from publishers and distributes them to subscribers based on their subscriptions. The ISBM aervice provider manages the routing and delivery of messages, ensuring that each consumer application receives the relevant messages according to its subscriptions.

#### Channels:

A channel is a logical conduit which messages flow between different devices or systems within a cluster. It serves as a means of organizing and directing the transmission of messages, providing a structured communication conduit for exchanging information. Channels help to categorize messages and ensure that they reach their intended recipients efficiently. In messaging systems, channels play a crucial role in facilitating communication, enabling devices and systems to interact and share data seamlessly across distributed environments while maintaining scalability and flexibility in message routing and delivery.

#### Topics:

A topic within the channel represents a distinct subject or category of messages that are published and subscribed to by devices or systems within a cluster. It serves as a container for related messages, organizing them based on common themes or events. Topics enable subscribers to express interest in specific types of messages and selectively consume relevant information. Messages published to a topic are broadcasted to all subscribers interested in that topic, facilitating asynchronous communication and event-driven interactions

#### ISBM Publication-Subscription Message Flow Diagram

![image](/Documents/Images/Publication_Flow.jpg)

#### Subscription Mechanism:

Devices or systems register their interest in receiving messages related to specific channels and Topics by subscribing to them. Subscriptions can be dynamic, allowing subscribers to subscribe or unsubscribe from channel at any time.

#### Decoupling:

The publication-subscription model enables loose coupling between publishers and subscribers. Provider and Consumer applications do not need to be aware of each other's existence, promoting scalability, flexibility, and modularity in distributed systems.

#### Asynchronous Communication:

Communication between providers and consumers is asynchronous. Providers produce messages at their own pace, and consumers consume messages as they become available in the message bus.

#### Scalability and Flexibility:

The publication-subscription model is highly scalable and flexible, allowing systems to handle large volumes of messages and accommodate dynamic changes in the number of providers and consumers.

### Request-Response model

### Project Information

### Use Cases

#### 1. Example of using Publication-Subscription model:  [Smart Agriculture Monitoring System](Documents/Use_Cases/Smart-Agriculture-Monitoring-System.md) 
#### 2. Example of using Request-Response model:  [Fleet Management System for Logistics](Documents/Use_Cases/Fleet_Management.md)
#### 3. Example of using both Publication-Subscription and Request-Response models:  [Flood Management System](Documents/Use_Cases/Flood-Management.md)
 

