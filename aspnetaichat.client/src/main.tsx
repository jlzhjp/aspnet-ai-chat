import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter, Routes, Route } from "react-router"
import ChatView from "./views/ChatView.tsx"
import './index.css'

const root = document.getElementById('root')!

createRoot(root).render(
    <StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<ChatView />} />
            </Routes>
        </BrowserRouter>
    </StrictMode>
)
