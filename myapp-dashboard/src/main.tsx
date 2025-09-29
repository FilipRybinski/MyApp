import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Shell from './Shell.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Shell />
  </StrictMode>,
)
