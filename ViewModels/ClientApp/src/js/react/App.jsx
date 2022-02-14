import Error from "./Components/ReactUtilities/Error";
import PeopleTable from "./Components/PeopleTable"; 
import CreateForm from "./Components/CreateForm";
import PersonDetails from "./Components/PersonDetails";
const routes = {
    index: 0,
    details: 1
}

class BackButton extends React.Component {
    render() {
        return (
            <div>
                <button className={"btn btn-primary"} onClick={() => this.props.onBack()}>Back</button>
            </div>
        );
    }
}

class PeopleApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [],
            route: routes.index,
            personId: null,
            status: null,
            isLoaded: false
        };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    back = () => {
        this.setState({
            route: routes.index,
            status: null
        })
    }

    personDetails = (id) => {
        this.setState({
            route: routes.details,
            personId: id
        });
    }

    personDelete = (id) => {
        const thatId = id;
        fetch("/React/Person/" + id, {method: 'DELETE'})
            .then(() => this.setState({
                status: 'Delete successful',
                route: routes.index,
                items: this.state.items.filter(function (person) {
                    return person.Id !== thatId
                })
            }));
    }

    render() {
        let status = null;

        if (this.state.status !== null) {
            status = <div className="p-3 mb-2 bg-success text-white">{this.state.status}</div>
        }

        switch (this.state.route) {
            case routes.details:
                return (
                    <div>
                        <BackButton onBack={this.back}/>
                        <h2>Details</h2>
                        <PersonDetails onPersonDelete={this.personDelete} personId={this.state.personId}/>
                    </div>
                );

            default:
                return (
                    <div>
                        <h1>Index Page</h1>
                        <PeopleTable
                            items={this.state.items}
                            isLoaded={this.state.isLoaded}
                            onPersonDetails={this.personDetails}
                        />
                        <CreateForm handleSubmit={this.handleSubmit}/>
                        {status}
                    </div>
                );
        }
    }

    handleSubmit = (person) => {
        const data = new FormData();
        data.append('Name', person.Name);
        data.append('CityId', person.CityId);
        data.append('PhoneNumber', person.PhoneNumber);
        for(var i=0;i< person.Languages.length;i++) {
            data.append("Languages[]", person.Languages[i]);
        }
        console.log(person.Languages)
        
        fetch("/React/Person/Create",
            {method: "Put", body: data})
            .then((response) => response.json())
            .then((person) => {
                this.setState(state => ({
                    items: state.items.concat(person),
                    status: 'Created person successfully'
                }))
            })
    }

    componentDidMount() {
        fetch("/React/People")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
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
}

ReactDOM.render(
    <PeopleApp />,
    document.getElementById('react-app')
);