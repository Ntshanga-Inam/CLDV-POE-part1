-- DATABASE CREATION

-- TABLE CREATION
CREATE TABLE Venue (
    VenueId INT PRIMARY KEY IDENTITY,
    VenueName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(200) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl NVARCHAR(255)
);

CREATE TABLE Event (
    EventId INT PRIMARY KEY IDENTITY,
    EventName NVARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    Description NVARCHAR(MAX),
    VenueId INT NULL,
    FOREIGN KEY (VenueId) REFERENCES Venue(VenueId)
);

CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY,
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    BookingDate DATE NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Event(EventId),
    FOREIGN KEY (VenueId) REFERENCES Venue(VenueId),
    CONSTRAINT UQ_VenueBooking UNIQUE (VenueId, BookingDate) -- Prevent double booking
);
ALTER TABLE dbo.Bookings
DROP CONSTRAINT UQ_VenueBooking;

-- Insert sample Venues
INSERT INTO Venue (VenueName, Location, Capacity, ImageUrl) VALUES
('Grand Ballroom', 'Downtown', 300, 'https://assets.anantara.com/image/upload/q_auto,f_auto,c_limit,w_756/media/minor/anantara/images/grand-hotel-krasnapolsky-amsterdam/meetings/grand-ballroom/anantara_grand_hotel_krasnapolsky_amsterdam_meetings_grand_ballroom_944x510-1.jpg'),
('Maracana', 'Sandton', 2500, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNS4vqSeIBodFuF8UunrGtRQrA-Nv4krOB4g&s'),
('Hallmark Rooftop', 'Doornfontein', 200, 'https://i0.wp.com/2summers.net/wp-content/uploads/2020/03/Hallmark-1972.jpg?resize=1000%2C667&ssl=1');

-- Insert sample Events
INSERT INTO Event (EventName, EventDate, Description, VenueId) VALUES
('Tech Conference 2025', '2025-05-12', 'A gathering of leading tech innovators.', 1),
('Wedding Ceremony', '2025-06-18', 'Private garden wedding.', 2),
('Startup Pitch Night', '2025-07-01', 'Pitching new business ideas to investors.', 3);

-- Insert sample Bookings
INSERT INTO Bookings (EventId, VenueId, BookingDate) VALUES
(1, 1, '2025-05-12'),
(2, 2, '2025-06-18'),
(3, 3, '2025-07-01');

