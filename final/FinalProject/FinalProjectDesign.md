# W06 Team Activity: Designer - Foundation 4 Final Project Design

Project option: Foundation 4 (four smaller programs, one per principle). None of the programs needs a menu or user input. Each `Program.cs` creates the objects, sets their values, and displays the results.

| Program | Principle | Classes |
| --- | --- | --- |
| 1. YouTube Videos | Abstraction | Video, Comment |
| 2. Online Ordering | Encapsulation | Order, Product, Customer, Address |
| 3. Event Planning | Inheritance | Event (base), Lecture, Reception, OutdoorGathering, Address |
| 4. Exercise Tracking | Polymorphism | Activity (base), Running, Cycling, Swimming |

All member variables in every program are private and use `_camelCase`. Classes and methods use TitleCase.

---

## Program 1: Abstraction with YouTube Videos

![[Program 1 YouTube Class Diagram.png]]

### Class: Video
Responsibility: store one video and the comments left on it.

**Attributes:**
- `_title: string`
- `_author: string`
- `_lengthSeconds: int`
- `_comments: List<Comment>`

**Behaviors (Methods):**
- `Video(title, author, lengthSeconds)`: Constructor. Sets the three values and creates an empty comments list.
- `AddComment(comment)`: Adds a `Comment` to the list.
- `GetCommentCount()`: Returns the number of comments.
- `GetTitle()`, `GetAuthor()`, `GetLengthSeconds()`, `GetComments()`: Getters.

### Class: Comment
Responsibility: store one comment.

**Attributes:** `_name: string`, `_text: string`

**Behaviors (Methods):**
- `Comment(name, text)`: Constructor.
- `GetName()`, `GetText()`: Getters.

### Interaction
1. `Program` creates 3-4 `Video` objects, and for each one creates 3-4 `Comment` objects and calls `video.AddComment(comment)`.
2. `Program` puts the videos in a `List<Video>`.
3. `Program` loops through the list. For each video it displays the title, author, length, and `GetCommentCount()`, then loops through `GetComments()` and displays each commenter's name and text.

`Video` is responsible for managing its own comments, and `Program` never touches the comment list directly.

---

## Program 2: Encapsulation with Online Ordering

![[Program 2 Ordering Class Diagram.png]]

### Class: Address
Responsibility: store a street address and answer questions about it.

**Attributes:** `_street`, `_city`, `_stateProvince`, `_country` (all `string`)

**Behaviors (Methods):**
- `Address(street, city, stateProvince, country)`: Constructor.
- `IsInUSA()`: Returns true if `_country` is the USA.
- `GetFullAddress()`: Returns all fields as one string, with newline characters between lines.

### Class: Customer
Responsibility: store a customer's name and address.

**Attributes:** `_name: string`, `_address: Address`

**Behaviors (Methods):**
- `Customer(name, address)`: Constructor.
- `GetName()`, `GetAddress()`: Getters.
- `LivesInUSA()`: Returns `_address.IsInUSA()`.

### Class: Product
Responsibility: store one product line and compute its cost.

**Attributes:** `_name: string`, `_productId: string`, `_pricePerUnit: double`, `_quantity: int`

**Behaviors (Methods):**
- `Product(name, productId, pricePerUnit, quantity)`: Constructor.
- `GetName()`, `GetProductId()`: Getters.
- `GetTotalCost()`: Returns `_pricePerUnit * _quantity`.

### Class: Order
Responsibility: hold a customer and their products, and produce the total and the labels.

**Attributes:** `_products: List<Product>`, `_customer: Customer`, `_usaShippingCost: int` (5), `_internationalShippingCost: int` (35)

**Behaviors (Methods):**
- `Order(customer)`: Constructor. Sets the customer and creates an empty product list.
- `AddProduct(product)`: Adds a product to the order.
- `GetTotalPrice()`: Sums each product's `GetTotalCost()` and adds one shipping cost ($5 if `_customer.LivesInUSA()`, otherwise $35).
- `GetPackingLabel()`: Returns a string listing the name and product id of each product.
- `GetShippingLabel()`: Returns a string with the customer's name and `GetFullAddress()`.

### Interaction
1. `Program` creates at least two `Order` objects, each with a `Customer` (who has an `Address`) and 2-3 `Product` objects added.
2. For each order, `Program` calls `GetPackingLabel()`, `GetShippingLabel()`, and `GetTotalPrice()` and displays the results.
3. Behind the scenes: `Order` asks `Customer.LivesInUSA()`, which asks `Address.IsInUSA()`. Each class only uses the public methods of the class it holds.

---

## Program 3: Inheritance with Event Planning

![[Program 3 Events Class Diagram.png]]

### Class: Address
Same as Program 3's own copy of the address class: `_street`, `_city`, `_stateProvince`, `_country`; constructor; `IsInUSA()`; `GetFullAddress()`.

### Class: Event (base class)
Responsibility: everything every kind of event shares.

**Attributes:** `_title`, `_description`, `_date`, `_time` (all `string`), `_address: Address`

**Behaviors (Methods):**
- `Event(title, description, date, time, address)`: Constructor.
- `GetStandardDetails()`: Returns title, description, date, time and the address.
- `GetFullDetails()` **(virtual)**: Returns the standard details plus the event type.
- `GetShortDescription()`: Returns the event type, title and date.
- `GetEventType()` **(virtual)**: Returns the type name.

### Class: Lecture : Event
**Attributes:** `_speaker: string`, `_capacity: int`
- `Lecture(title, description, date, time, address, speaker, capacity)`: Constructor, calls `base(...)`.
- `GetFullDetails()` **(override)**: Standard details plus the speaker name and capacity.
- `GetEventType()` **(override)**: Returns "Lecture".

### Class: Reception : Event
**Attributes:** `_rsvpEmail: string`
- `Reception(title, description, date, time, address, rsvpEmail)`: Constructor, calls `base(...)`.
- `GetFullDetails()` **(override)**: Standard details plus the RSVP email.
- `GetEventType()` **(override)**: Returns "Reception".

### Class: OutdoorGathering : Event
**Attributes:** `_weatherForecast: string`
- `OutdoorGathering(title, description, date, time, address, weatherForecast)`: Constructor, calls `base(...)`.
- `GetFullDetails()` **(override)**: Standard details plus a statement of the weather.
- `GetEventType()` **(override)**: Returns "Outdoor Gathering".

### Interaction
1. `Program` creates at least one of each event type and sets all of its values (including an `Address`).
2. For each event, `Program` calls `GetStandardDetails()`, `GetFullDetails()` and `GetShortDescription()` and displays the results.
3. The shared data and methods live only in `Event`. Each derived class adds just its own attributes and overrides `GetFullDetails()` and `GetEventType()`. `GetShortDescription()` calls `GetEventType()`, so it works correctly for every type without being overridden.

---

## Program 4: Polymorphism with Exercise Tracking

![[Program 4 Exercise Class Diagram.png]]

### Class: Activity (base class)
Responsibility: the data and summary shared by every kind of activity.

**Attributes:** `_date: DateTime`, `_lengthMinutes: int`

**Behaviors (Methods):**
- `Activity(date, lengthMinutes)`: Constructor.
- `GetLengthMinutes()`: Getter.
- `GetDistance()` **(virtual)**: Returns the distance in miles (base version returns 0).
- `GetSpeed()` **(virtual)**: Returns `(GetDistance() / _lengthMinutes) * 60`.
- `GetPace()` **(virtual)**: Returns `_lengthMinutes / GetDistance()`.
- `GetSummary()`: Returns a string like `03 Nov 2022 Running (30 min): Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile`, built from the methods above and the class name.

### Class: Running : Activity
**Attributes:** `_distance: double`
- `Running(date, lengthMinutes, distance)`: Constructor, calls `base(...)`.
- `GetDistance()` **(override)**: Returns `_distance`.

### Class: Cycling : Activity
**Attributes:** `_speed: double`
- `Cycling(date, lengthMinutes, speed)`: Constructor, calls `base(...)`.
- `GetDistance()` **(override)**: Returns `(_speed / 60) * _lengthMinutes`.
- `GetSpeed()` **(override)**: Returns `_speed`.
- `GetPace()` **(override)**: Returns `60 / _speed`.

### Class: Swimming : Activity
**Attributes:** `_laps: int`
- `Swimming(date, lengthMinutes, laps)`: Constructor, calls `base(...)`.
- `GetDistance()` **(override)**: Returns `_laps * 50 / 1000 * 0.62` (laps are 50 meters, result in miles).

### Method Overriding Summary

| Method | Activity (base) | Running | Cycling | Swimming |
| --- | --- | --- | --- | --- |
| `GetDistance()` | virtual, returns 0 | override: `_distance` | override: from speed and time | override: from laps |
| `GetSpeed()` | virtual: distance / minutes * 60 | inherits | override: `_speed` | inherits |
| `GetPace()` | virtual: minutes / distance | inherits | override: 60 / speed | inherits |

### Interaction
1. `Program` creates at least one `Running`, one `Cycling` and one `Swimming` activity.
2. `Program` puts all of them in the same `List<Activity>`.
3. `Program` loops through the list and calls `GetSummary()` on each `Activity`. `GetSummary()` calls `GetDistance()`, `GetSpeed()` and `GetPace()`, and because they are virtual, each object runs its own version without `Program` checking which type it is.
