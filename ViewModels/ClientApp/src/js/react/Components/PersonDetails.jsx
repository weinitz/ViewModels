import Error from "./ReactUtilities/Error.jsx";

class DeletePersonButton extends React.Component {
    render() {
        return (
            <button className={"btn btn-danger"} onClick={() => this.props.onPersonDelete(this.props.personId)}>Delete Person</button>
        );
    }
}

class PersonDetailsTable extends React.Component {
    render() {
        console.log(this.props)
        const person = this.props.person;

        return (
            <table className="table">
                <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Name</th>
                    <th scope="col">Location</th>
                    <th scope="col">Phone</th>
                    <th scope="col">Languages</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td scope="col">{person.Id}</td>
                    <td scope="col">{person.Name}</td>
                    <td scope="col">{person.CityName}, {person.CountryName}</td>
                    <td scope="col">{person.PhoneNumber}</td>
                    <td scope="col">{person.Languages}</td>
                </tr>
                </tbody>
            </table>
        );
    }
}

class PersonDetails extends React.Component {
    state = {
        isLoaded: false,
        error: null,
        person: null
    }

    componentDidMount(){
        // fetch full person details
        console.log("componentDidMount")
        console.log(this.props)
        fetch("/React/Person/" + this.props.personId)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        person: result
                    })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            );
    }

    render() {
        const { error, isLoaded, person} = this.state;
        if (error) {
            return <Error message={error.message}/>
        }
        else if (!isLoaded){
            return <div>Loading Person...</div>
        } else {
            return (
                <div>
                    <PersonDetailsTable person={person}/>
                    <DeletePersonButton onPersonDelete={this.props.onPersonDelete} personId={person.Id}/>
                </div>
            );
        }
    }
}

export default PersonDetails;