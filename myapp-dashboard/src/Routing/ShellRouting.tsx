import {createRootRoute, createRouter, RouterProvider} from "@tanstack/react-router";
import {shellRoute} from "./ShellRoute.tsx";

export const rootRoute = createRootRoute()



const routeTree = rootRoute.addChildren([shellRoute])
const router = createRouter({ routeTree })

export const ShellRouting = () => {
    return <RouterProvider router={router}/>
}