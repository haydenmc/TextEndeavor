import * as signalR from "@aspnet/signalr";

class Main {
    private gameConnection: signalR.HubConnection;

    constructor() {
        this.gameConnection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();
        this.gameConnection.on("CommandResponse", this.onCommandResponse);
    }

    public start(): void {
        // Set up elements
        document.querySelector("main > form").addEventListener("submit", (e: Event) => {
            e.preventDefault();
            let inputElement: HTMLInputElement = document.querySelector("main > form > input")
            let command = inputElement.value;
            inputElement.value = "";
            this.sendCommand(command);
        });

        // Connect
        this.gameConnection.start();
    }

    public sendCommand(command: string): void {
        this.gameConnection.send("SendCommand", command);
    }

    private onCommandResponse(response: string): void {
        let outputEl = document.createElement("output");
        outputEl.textContent = response;
        document.querySelector("main").insertBefore(outputEl, document.querySelector("main > form"));
    }
}

window.addEventListener("load", () => {
    new Main().start();
});