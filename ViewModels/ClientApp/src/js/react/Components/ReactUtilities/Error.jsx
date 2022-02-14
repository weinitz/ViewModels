class Error extends React.Component {
    render() {
        return <div className="p-3 mb-2 bg-danger text-white">Error: {this.props.message}</div>
    }
}

export default Error;