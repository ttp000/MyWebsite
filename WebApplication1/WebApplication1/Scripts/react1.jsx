/*require("react")
require("react-dom")*/
import React from "react"
import ReactDOM from "react-dom"

const { useState } = React;

class myClass extends React.Component {
    render() {
        return (
            < div >
                < h4 > Hell world!</h4 >
            </div >
        )
    }
}

ReactDOM.render(<myClass />, document.getElementById("txtReact"));