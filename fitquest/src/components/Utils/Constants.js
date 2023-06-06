export const ROUTE_CONSTANTS = {
    API_URL: "https://localhost:7214/api",  
}

export const getCurrentUser = () => {
    return JSON.parse(localStorage.getItem("fq_user"))
} 

// COLORS
export const DARK_GRAY = '#18181b'

export const BLACK = '#09090b'

export const WHITE = '#f3f4f6'

export const DIRTY_WHITE = '#e5e7eb'

export const SLATE = '#2A2B37'

export const LIGHT_GRAY = '#6b7280'