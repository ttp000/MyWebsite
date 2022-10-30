/*const react = require("react")
const reactDom = require("react-dom")*/
/*import React from 'react';
import ReactDOM from 'react-dom';*/

//const { useState } = require("react");

//const { useState } = React;

//import { useState } from 'react';

/*class MyClass extends React.Component {
    render() {
        return (
            <div>
                <p> <b>Hello world!</b> -- This is React on ASP.NET MVC </p>
            </div>
        );
    }
}*/

function MyClass() {
    return (
        <div>
            <b>Hello World!</b> -- This is React function()
        </div>
    )
}

class ButtonClick extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            count: 0
        };
    }

    render() {
        return (
            <div>
                <h4>React useState Button click {this.state.count}</h4>
                <button id="myBtn" onClick={() => this.setState({ count: this.state.count + 1 })}>Click</button>
            </div>
        )
    }
}

/*function ButtonClick() {
    const [count, setCount] = useState(0);

    return (
        <div>
            <h4>React useState Button Click {count}</h4>
            <button onClick={() => setCount(count + 1)}>Click</button>
        </div>
    );
}*/

const element = document.getElementById("txtReact");

const root = ReactDOM.createRoot(element);

//const root = ReactDOM.createRoot(document.getElementById("txtReact"));

root.render(<ButtonClick />);