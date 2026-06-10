// API Configuration
const API_BASE_URL = 'http://localhost:5041/api';

// API Client
const apiClient = {
    // Customers
    async getCustomers() {
        const response = await fetch(`${API_BASE_URL}/customers`);
        if (!response.ok) throw new Error('Failed to fetch customers');
        return await response.json();
    },

    async getCustomer(id) {
        const response = await fetch(`${API_BASE_URL}/customers/${id}`);
        if (!response.ok) throw new Error('Failed to fetch customer');
        return await response.json();
    },

    async createCustomer(data) {
        const response = await fetch(`${API_BASE_URL}/customers`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        if (!response.ok) throw new Error('Failed to create customer');
        return await response.json();
    },

    async updateCustomer(id, data) {
        const response = await fetch(`${API_BASE_URL}/customers/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        if (!response.ok) throw new Error('Failed to update customer');
        return await response.json();
    },

    async deleteCustomer(id) {
        const response = await fetch(`${API_BASE_URL}/customers/${id}`, {
            method: 'DELETE'
        });
        if (!response.ok) throw new Error('Failed to delete customer');
        return response.ok;
    },

    // Shipments
    async getShipments() {
        const response = await fetch(`${API_BASE_URL}/shipments`);
        if (!response.ok) throw new Error('Failed to fetch shipments');
        return await response.json();
    },

    async getShipment(id) {
        const response = await fetch(`${API_BASE_URL}/shipments/${id}`);
        if (!response.ok) throw new Error('Failed to fetch shipment');
        return await response.json();
    },

    async getShipmentByTracking(trackingNumber) {
        const response = await fetch(`${API_BASE_URL}/shipments/tracking/${trackingNumber}`);
        if (!response.ok) throw new Error('Shipment not found');
        return await response.json();
    },

    async createShipment(data) {
        const response = await fetch(`${API_BASE_URL}/shipments`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        if (!response.ok) throw new Error('Failed to create shipment');
        return await response.json();
    },

    async updateShipment(id, data) {
        const response = await fetch(`${API_BASE_URL}/shipments/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        if (!response.ok) throw new Error('Failed to update shipment');
        return await response.json();
    },

    async updateShipmentStatus(id, status) {
        const response = await fetch(`${API_BASE_URL}/shipments/${id}/status`, {
            method: 'PATCH',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ status })
        });
        if (!response.ok) throw new Error('Failed to update shipment status');
        return await response.json();
    },

    async deleteShipment(id) {
        const response = await fetch(`${API_BASE_URL}/shipments/${id}`, {
            method: 'DELETE'
        });
        if (!response.ok) throw new Error('Failed to delete shipment');
        return response.ok;
    },

    // Dashboard
    async getDashboard() {
        const response = await fetch(`${API_BASE_URL}/dashboard`);
        if (!response.ok) throw new Error('Failed to fetch dashboard');
        return await response.json();
    }
};

// Utility Functions
function showAlert(message, type = 'info') {
    const alertHtml = `
    <div class="alert alert-${type} alert-dismissible fade show" role="alert">
      ${message}
      <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
  `;
    const alertContainer = document.getElementById('alertContainer');
    if (alertContainer) {
        alertContainer.innerHTML = alertHtml;
        window.scrollTo(0, 0);
    }
}

function getStatusBadgeClass(status) {
    const statusMap = {
        'Created': 'badge-created',
        'InWarehouse': 'badge-inwarehouse',
        'InTransit': 'badge-intransit',
        'Delivered': 'badge-delivered',
        'Cancelled': 'badge-cancelled'
    };
    return statusMap[status] || 'badge-secondary';
}

function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleDateString() + ' ' + date.toLocaleTimeString();
}