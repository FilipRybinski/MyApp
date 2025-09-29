import {createRoute} from "@tanstack/react-router";
import {rootRoute} from "./ShellRouting.tsx";

export const shellRoute = createRoute({
    getParentRoute: () => rootRoute,
    path: '/',
    component: () => <div>Hello World</div>,
})