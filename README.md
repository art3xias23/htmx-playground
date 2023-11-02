# Hypermedia introduction
### [URL to Book](https://hypermedia.systems/hypermedia-reintroduction/)

### What is hypermedia?
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

# How SPA's operate

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

### MPA
- is a modern name for the old, Web 1.0 way of building web applications, using links and forms located on multiple web pages, submitting HTTP requests and getting HTML responses.
