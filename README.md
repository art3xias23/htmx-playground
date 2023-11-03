# Hypermedia introduction
### [URL to Book](https://hypermedia.systems/hypermedia-reintroduction/)

## What is hypermedia?
- "Hypermedia is a media, for example a text, that includes non-linear branching
  from one location in the media to another, via, for example, hyperlinks
  embedded in the media."

  - "Hyperlinks are a canonical example of what is called a hypermedia control"

  - "A hypermedia control is an element in a hypermedia that describes (or
    controls) some sort of interaction, often with a remote server, by encoding
    information about that interaction directly and completely within itself."

`{ (1)
  "id": 42, (2)
  "email" : "json-example@example.org" (3)
}`

# How SPAs(Single Page Applications) operate

- The JavaScript code above converts the JSON text received from the server into a JavaScript object by calling the json() method on it. This new JavaScript object is then handed off to the updateUI() method.

- The updateUI() method is responsible for updating the UI based on the data encoded in the JavaScript Object, perhaps by displaying the contact in a bit of HTML generated via a client-side template in the JavaScript application.

- updateUI has a tight coupling with the json endpoint, which means that if the
json is updated the updateUI will surely need to be updated as well.


- Most modernday frameworks like React, Angular, Vue have created a two way
binding mechanism between the model (domain) and the UI. The UI can update the
model and the model can update the UI(the UI reacts to the change). These two
items communicate via plain json data.
 - The above bypasses any hypermedia way of communication

 - "HTML is still used to build user interfaces, but the hypermedia aspect of the
 two major hypermedia controls, anchors and forms, are unused. Neither tag
 interacts with a server via their native hypermedia mechanism. Rather, they
 become user interface elements that drive local interactions with the in-memory
 domain model via JavaScript, which is then synchronized with the server using
 plain data JSON APIs."

### Why would we consider using an older and cluncky technology to build webpages? 
  - It is simple 
  - Tolerant to content and API changes. It thrives on them!
  - SPA infrastryctyre has become extremely complex often requiring an entire
    team to manage
  - Constant changes to json api to support application needs? 

### Why isn't hypermedia the default industry standard?
- HTML has not been updated in terms of hypermedia for almost 3 decades.
  Developers still have only anchor tags and forms as hypermedia controls and
  they can only still issue POST and GET requests. It was the lack of these user
  interfaces that led the developers to javascript as it filled the void. The
  shift was not driven by any inherent superiority as a system architecture.

### MPA (Multi Page Application)
- is a modern name for the old, Web 1.0 way of building web applications, using links and forms located on multiple web pages, submitting HTTP requests and getting HTML responses.

### HDA (Hypermedia-Driven Application)
- A web application that uses hypermedia and hypermedia exchanges as its primary mechanism for communicating with a server.

`<button hx-get="/contacts/1" hx-target="#contact-ui">
    Fetch Contact
 </button>`

 - Issues a get request to /contacts/1
 - Replaces the contact-ui
 - As with the JS powered button this button has been annotated with some
   attributes. However, no (explicit) Javascript scripting

## When should we use Hypermedia?

- Hypermedia **is often, __not always__** , a great choice for a web application.
  - News Sites
  - Shopping Sites
  - Message Boards
  - Mainly text and images (which is exactly what the web was designed to do)
## When not to use Hypermedia?
- Online Spreadsheet
    - One cell change could trigger a chain of cascading changes
       - Or even worse, could occur on every keystroke
    - Introducing a hypermedia-style server round trip on every cell change
    would hurt performance
    - However, hypermedia-transfer can still be used on a settings page and a
        heavy javascript library/framework could be used on the core of the
        interactivity website

## Hypermedia is a sophisticated, modern system architecture

## DIV Soup Note

`<div class="bg-accent padding-4 rounded-2" onclick="doStuff()">Do stuff</div>`

- The above has two issues:
  - It's not focusable, the tab key won't get us there
  - There is no way for assistive tools to tell that it's a button
- Easy fix

`<div class="bg-accent padding-4 rounded-2"
  role="button"
  tabindex="0"
  onclick="doStuff()">Do stuff</div>`

- Note
   - Become friendly with the 113 tags currently available in the html spec


# Components of a hypermedia system

## Hypermedia system consists of a number of components:
- Hypermedia such as HTML
- A network protocol such as HTTP
- A server that presents a hypermedia API responding to network requests with
    hypermedia responses
- A client that properly interprets the responses

## Components of a Hypermedia System
## Hypermedia
- What makes hypermedia a hypermedia is the presence of hypermedia controls
    (e.g. anchors, forms)
- In the case of HTML these links specify the target of their operations using
    URL (Uniform Resource Locator)
    - URLs point to a resource
    - URLs tell how a resource should retrieved
## Hypermedia Servers
 - Any server that can respond to an HTTP Request with an HTTP Response
 - This gives great flexibility and freedom to chose the backend of the
     application. 
 - Could be anything, as since HTTP is so simple a server could be spun up in
     every language
 - HOWL (**Hyperlinks on whatever you like**)
### Article mentioning that HATEAOS is REST LEVEL 3 (Here){https://techblog.commercetools.com/graphql-and-rest-level-3-hateoas-70904ff1f9cf}
### Roy Fielding on how REST Api's should be hypertext-driven
(Here)[https://roy.gbiv.com/untangled/2008/rest-apis-must-be-hypertext-driven#div-comment-724]

## Hypermedia Clients
- A good client is required to handle the hypermedia coming back from the
    server.
- ~~Building a good hypermedia client is hard!~~

## REST
### Constraints

1. Client - Server
2. Stateless
3. Caching
4. Uniform Interface (contains 4 sub-constraints)
    4.1 Identification of Resource (URLs)
    4.2 Manipulation of resources through representation
      - Representation of resources is transfered between client and server
      - Representation can contain data and metadata about requests ("control
          data" like an HTTP method or response code)
    4.3 Self-Descriptive Messages
      - all information necessary to both display and also operate on the data being represented must be present in the response
`{
  "name": "Joe Smith",
  "email": "joe@example.org",
  "status": "Active"
}`

In the above case the clients needs to know exactly what each one of the items
is an how to display them.

`<html lang="en">
<body>
<h1>Joe Smith</h1>
<div>
    <div>Email: joe@example.bar</div>
    <div>Status: Active</div>
</div>
<p>
    <a href="/contacts/42/archive">Archive</a>
</p>
</body>
</html>`

In the above example the client only needs to be able to display the hypermedia
controls. It does need to know what a contact is at all.

    4.4 HATEOAS (Hypermedia As The Engine of Application State)
        - The important point to notice here is that, by virtue of being a self-describing message, the HTML response now shows that the “Archive” operation is no longer available, and a new “Unarchive” operation has become available. The HTML representation of the contact encodes the state of the application; it encodes exactly what can and cannot be done with this particular representation, in a way that the JSON representation does not.

5. Layered System constraint
    - Could make use of Intermediary servers called Content Delivery Networks,
        which will store data from the origin server in order to deliver it to a
        client more closely positioned to the intermediary server than the
        server
