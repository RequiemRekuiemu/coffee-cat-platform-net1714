-- Insert sample data into the 'shop' table
INSERT INTO shop (name, location, description, contactNumber)
VALUES ('Coffee Cat', '123 Main Street', 'A cozy coffee shop', '123-456-7890');

-- Insert sample data into the 'area' table
INSERT INTO area (location, shopID)
VALUES ('Indoor Seating', 1),
       ('Outdoor Patio', 1),
       ('Private Lounge', 1);

-- Insert sample data into the 'table' table
INSERT INTO "table" (status, areaID)
VALUES (1, 1),
       (1, 2),
       (1, 3);

-- Insert sample data into the 'customer' table
INSERT INTO customer (name, phone, email, password, status)
VALUES ('John Doe', '555-1234', 'john@gmail.com', '123', 1),
       ('Jane Smith', '555-5678', 'jane@gmail.com', '123', 1),
       ('Bob Johnson', '555-8765', 'bob@gmail.com', '123', 1);

-- Insert sample data into the 'cat' table
INSERT INTO cat (name, gender, breed, birthday, healthStatus, shopID)
VALUES ('Whiskers', 0, 'Tabby', '2020-01-01', 'Healthy', 1),
       ('Mittens', 1, 'Persian', '2019-03-15', 'Vaccinated', 1),
       ('Shadow', 0, 'Siamese', '2021-05-10', 'Playful', 1);

-- Insert sample data into the 'role' table
INSERT INTO role (name, description)
VALUES ('Manager', 'Manages the coffee shop'),
       ('Staff', 'Serves customers');
       
	   
-- Insert sample data into the 'staff' table
INSERT INTO staff (name, gender, phone, email, password, status, roleId, shopID)
VALUES ('Alice', 1, '555-1111', 'alice@gmail.com', 'password111', 1, 1, 1),
       ('Bob', 0, '555-2222', 'bob@gmail.com', 'password222', 1, 2, 1),
       ('Charlie', 1, '555-3333', 'charlie@gmail.com', 'password333', 1, 3, 1);

-- Insert sample data into the 'product' table
INSERT INTO product (name, description, price, quantity, shopID)
VALUES ('Espresso', 'Strong black coffee', 3.99, 100, 1),
       ('Cappuccino', 'Espresso with steamed milk', 4.99, 80, 1),
       ('Latte', 'Espresso with frothy milk', 5.49, 50, 1);

-- Insert sample data into the 'promotion' table
INSERT INTO promotion (name, description, promotionType, promotionAmount)
VALUES ('Happy Hour', '50% off on all drinks', 1, 50),
       ('Loyalty Discount', '10% off for returning customers', 1, 10),
       ('Combo Deal', 'Buy one get one free', 0, 0);

-- Insert sample data into the 'reservation' table
INSERT INTO reservation (bookingDay, startTime, endTime, status, totalPrice, customerID)
VALUES ('2024-02-25', '10:00', '12:00', 1, 15.00, 1),
       ('2024-02-26', '14:00', '16:00', 1, 20.00, 2),
       ('2024-02-27', '18:00', '20:00', 1, 25.00, 3);

-- Insert sample data into the 'reservationTable' table
INSERT INTO reservationTable (reservationID, tableID)
VALUES (1, 1),
       (2, 2),
       (3, 3);

-- Insert sample data into the 'areaCat' table
INSERT INTO areaCat (areaID, catID, date)
VALUES (1, 1, '2024-02-25'),
       (2, 2, '2024-02-26'),
       (3, 3, '2024-02-27');

-- Insert sample data into the 'bill' table
INSERT INTO bill (totalPrice, status, paymentTime, note, reservationID, staffID, promotionID)
VALUES (25.00, 1, GETDATE(), 'No special requests', 1, 1, 1),
       (30.00, 1, GETDATE(), 'VIP seating', 2, 2, 2),
       (15.00, 1, GETDATE(), 'Outdoor view', 3, 3, 3);

-- Insert sample data into the 'billProduct' table
INSERT INTO billProduct (quantity, billID, productID)
VALUES (2, 1, 1),
       (1, 2, 2),
       (3, 3, 3);