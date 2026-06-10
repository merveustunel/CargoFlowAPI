# CargoFlow Web Frontend

A simple, clean Bootstrap-based frontend for the CargoFlow API. Built with vanilla HTML, CSS, and JavaScript using Bootstrap 5 CDN.

## Overview

The CargoFlow Web frontend provides a user-friendly interface to interact with the CargoFlow API. It includes:

- **Dashboard** - Real-time metrics on shipments and customers
- **Customers** - Manage customer records (Create, Read, Update, Delete)
- **Shipments** - Manage shipments with status tracking and updates
- **Public Tracking** - Public shipment tracking by tracking number

## Features

✅ Responsive Bootstrap 5 design  
✅ Clean, recruiter-friendly UI  
✅ Real-time data fetching from API  
✅ CRUD operations for customers and shipments  
✅ Shipment status management  
✅ Public tracking page  
✅ Error handling and user feedback  
✅ No external frameworks (React, Vue, etc.)  

## File Structure

```
CargoFlow.Web/
├── index.html           # Dashboard page
├── customers.html       # Customer management page
├── shipments.html       # Shipment management page
├── tracking.html        # Public shipment tracking page
├── css/
│   └── styles.css       # Custom styles
└── js/
    └── api.js           # API client and utility functions
```

## Getting Started

### Prerequisites

- CargoFlow API running at `http://localhost:5041/api`
- A modern web browser (Chrome, Firefox, Safari, Edge)
- A simple HTTP server (optional, for serving HTML files)

### Running the Frontend

#### Option 1: Direct File Opening
1. Navigate to the `CargoFlow.Web` folder
2. Open `index.html` in a web browser
3. Navigate between pages using the top navigation menu

#### Option 2: Using a Local Server (Recommended)

**Using Python 3:**
```bash
cd CargoFlow.Web
python -m http.server 8000
```
Then open `http://localhost:8000` in your browser.

**Using Node.js (http-server):**
```bash
npx http-server CargoFlow.Web
```

**Using .NET:**
```bash
dotnet tool install --global dotnet-serve
dotnet serve --directory CargoFlow.Web
```

## API Configuration

The frontend connects to the CargoFlow API at:
```
http://localhost:5041/api
```

To change this, edit the `API_BASE_URL` in `js/api.js`:
```javascript
const API_BASE_URL = 'http://localhost:5041/api';
```

## Pages

### Dashboard (index.html)
Displays real-time statistics:
- Total shipments
- Delivered shipments
- In-transit shipments
- Cancelled shipments
- Total customers

Quick action buttons for common tasks.

### Customers (customers.html)
Manage customer records:
- View all customers in a table
- Add new customers (modal form)
- Edit existing customers
- Delete customers
- Search and sort (Bootstrap table)

### Shipments (shipments.html)
Manage shipments:
- View all shipments with status badges
- Create new shipments (modal form)
- Edit shipment details
- Update shipment status with dedicated modal
- Delete shipments
- Track shipment by tracking number

**Status Options:**
- Created
- InWarehouse
- InTransit
- Delivered
- Cancelled

### Tracking (tracking.html)
Public-facing shipment tracking:
- Search shipment by tracking number
- View shipment details
- Visual status timeline
- Current status indicator
- User-friendly information display

## Technology Stack

- **HTML5** - Semantic markup
- **CSS3** - Custom styling with CSS variables
- **JavaScript (ES6+)** - Vanilla JS with async/await
- **Bootstrap 5** - Responsive CSS framework via CDN
- **Fetch API** - HTTP client for API calls

## Features in Detail

### Responsive Design
All pages are fully responsive and work on:
- Desktop (1200px+)
- Tablet (768px - 1199px)
- Mobile (< 768px)

### Error Handling
- User-friendly error messages
- API error feedback
- Validation before submission
- Loading indicators

### Data Validation
- Required field validation
- Email format validation
- Number range validation
- Confirmation dialogs for destructive actions

### User Experience
- Modal dialogs for forms
- Status badges with color coding
- Formatted dates and times
- Loading spinners
- Alert notifications

## Color Scheme

- **Primary:** #2c3e50 (Dark Blue-Gray)
- **Secondary:** #3498db (Sky Blue)
- **Success:** #27ae60 (Green)
- **Danger:** #e74c3c (Red)
- **Warning:** #f39c12 (Orange)

## Status Badge Colors

- **Created:** Gray
- **InWarehouse:** Orange
- **InTransit:** Blue
- **Delivered:** Green
- **Cancelled:** Red

## API Endpoints Used

The frontend calls these API endpoints:

**Customers:**
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `POST /api/customers` - Create customer
- `PUT /api/customers/{id}` - Update customer
- `DELETE /api/customers/{id}` - Delete customer

**Shipments:**
- `GET /api/shipments` - Get all shipments
- `GET /api/shipments/{id}` - Get shipment by ID
- `GET /api/shipments/tracking/{trackingNumber}` - Get by tracking number
- `POST /api/shipments` - Create shipment
- `PUT /api/shipments/{id}` - Update shipment
- `PATCH /api/shipments/{id}/status` - Update status
- `DELETE /api/shipments/{id}` - Delete shipment

**Dashboard:**
- `GET /api/dashboard` - Get dashboard metrics

## Troubleshooting

### "Error loading data. Make sure the API is running."
- Verify the API is running at `http://localhost:5041`
- Check the `API_BASE_URL` in `js/api.js`
- Ensure CORS is enabled on the API (should be in ASP.NET Core by default)

### Shipment not found when tracking
- Verify the tracking number is correct
- Ensure the shipment exists in the database
- Check if the API is returning the correct data

### Modal forms not working
- Ensure Bootstrap 5 JavaScript bundle is loaded
- Check browser console for errors
- Verify form inputs have correct IDs

## Browser Support

- Chrome 90+
- Firefox 88+
- Safari 14+
- Edge 90+
- Mobile browsers (iOS Safari, Chrome Mobile)

## Development Notes

### Adding New Features
1. Add new HTML page in `CargoFlow.Web/` root
2. Import `js/api.js` and `css/styles.css`
3. Use the navigation template from existing pages
4. Use the `apiClient` object to call API endpoints

### Extending API Client
Add new methods to the `apiClient` object in `js/api.js`:
```javascript
async getNewResource() {
  const response = await fetch(`${API_BASE_URL}/newresource`);
  if (!response.ok) throw new Error('Error message');
  return await response.json();
}
```

### Custom Styling
Modify `css/styles.css` to customize:
- Colors (CSS variables at top)
- Fonts
- Spacing
- Responsive breakpoints

## Future Improvements

- [ ] Pagination for large data sets
- [ ] Advanced filtering and sorting
- [ ] Export data to CSV/Excel
- [ ] Print functionality
- [ ] Dark mode theme
- [ ] Offline support with service workers
- [ ] Real-time updates with WebSockets
- [ ] File upload for shipment documents
- [ ] Email notifications integration
- [ ] User authentication

## License

This project is provided as-is for educational and development purposes.

---

**Last Updated:** June 10, 2026  
**Version:** 1.0.0
