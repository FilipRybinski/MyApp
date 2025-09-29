import {ShellProvider} from "./Providers/ShellProvider.tsx";
import {ShellRouting} from "./Routing/ShellRouting.tsx";

function Shell() {
  return <ShellProvider>
    <ShellRouting/>
  </ShellProvider>
}

export default Shell
