
# Real Estate Management System

This project was developed as part of the **Advanced Programming Languages II** course. The goal was to create a C# application for managing real estate properties for a fictional real estate agency.

## Project Description

The application manages various types of properties (e.g., houses, apartments) and allows the user to perform different operations such as adding properties, calculating their value, and searching for specific properties based on criteria.

### Classes and Structure

1. **Ingatlan (Property) Class**:
   - **Fields and Properties**:
     - **Helyrajzi Szám (Registry Number)**: A string value that uniquely identifies the property. It must follow specific format rules.
     - **Szélesség (Width) and Hossz (Length)**: Integer values representing the dimensions of the property.
     - **Állapot (Condition)**: An enumeration indicating the property's condition (e.g., New, Renovated).
     - **Alapterület (Area)**: A read-only property calculated as the product of the width and length.
   - **Methods**:
     - **Vetelar (Purchase Price)**: Calculates the purchase price based on the property's area and condition.
     - **ToString() and Equals()**: Overridden methods to provide formatted output and compare properties by their registry number.

2. **CsaladiHaz (Family House) Class**:
   - **Fields and Properties**:
     - **Telek Szélesség (Plot Width) and Telek Hossz (Plot Length)**: Dimensions of the plot, which must be greater than or equal to the property dimensions.
     - **Szintek Száma (Number of Floors)**: The number of floors in the house, with a minimum of 1 and a maximum of 3.
     - **Kert Területe (Garden Area)**: Read-only property representing the garden area, calculated as the difference between the plot and building area.
   - **Methods**:
     - **Vetelar()**: Overrides the base class method to include the value of the garden area in the purchase price calculation.

3. **IngatlanIroda (Real Estate Agency) Class**:
   - **Fields and Properties**:
     - **Ingatlanok Listája (List of Properties)**: A list that stores all property objects.
     - **Családi Házak (Family Houses)**: Filters and returns only the family houses from the property list.
     - **Legolcsóbb Felújítandó Családi Ház (Cheapest Renovation-Needed House)**: Finds and returns the cheapest family house that needs renovation.
     - **Indexer**: Allows accessing properties by their registry number.
   - **Methods**:
     - **AddIngatlan (Add Property)**: Adds a property to the list if it doesn't already exist.
     - **CsaladiHazakAdottArig (Family Houses Under a Given Price)**: Returns a list of family houses that meet specific condition and price criteria.

4. **Main Program**:
   - The main program reads property data from a CSV file, creates the appropriate objects, and stores them in the real estate agency. It then performs various operations such as searching and listing properties.

## How to Run

1. **Compile** the project using a C# compiler or open it in Visual Studio.
2. **Run** the program, which will read data from the `ingatlanok.csv` file.
3. The program will display the results of various operations in the console.

## Files

- `Ingatlan.cs`: Contains the base class for properties.
- `CsaladiHaz.cs`: Contains the derived class for family houses.
- `IngatlanIroda.cs`: Contains the class for managing the list of properties.
- `Program.cs`: The main entry point for the application.

## License

This project is for educational purposes and is part of the coursework for the Advanced Programming Languages II course.
