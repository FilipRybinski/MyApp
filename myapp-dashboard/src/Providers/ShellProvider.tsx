import {ThemeProvider} from "@mui/material";
import {theme} from "../../theme/theme.ts";

export const ShellProvider =()=> {
    return (<ThemeProvider theme={theme}>

    </ThemeProvider>)
}