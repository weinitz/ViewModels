const sortAsc   = 1;
const sortDesc  = -1;

class PeopleTable extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            sortDirection: 0
        };
    }

    render() {
        if (!this.props.isLoaded){
            return <div>Loading table...</div>
        } else {
            return (
                <table className="table">
                    <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name <button className={"btn btn-sm"} onClick={this.sortTable}>&#8645;</button></th>
                        <th scope="col">Location</th>
                        <th scope="col">Phone</th>
                        <th scope="col">Languages</th>
                        <th scope="col">Handle</th>
                    </tr>
                    </thead>
                    <PeopleTableRows
                        onPersonDetails={this.props.onPersonDetails}
                        items={this.props.items}
                        sortOrder={this.state.sortDirection}
                    />
                </table>
            );
        }
    }

    sortTable = () => {
        let sortDirection = sortAsc;
        let columnToSort = 'firstName';

        if (this.state.sortDirection === sortAsc){
            sortDirection = sortDesc;
        }

        this.props.items.sort((x1, x2) => x1[columnToSort] < x2[columnToSort] ? -1 * sortDirection : sortDirection);
        this.setState({
            sortDirection, items: this.props.items
        });
    }
}

class PeopleTableRows extends React.Component {
    render() {
        return (
            <tbody>
            {
                this.props.items.map(
                    person =>
                        <tr key={person.Id}>
                            <td>{person.Id}</td>
                            <td>{person.Name}</td>
                            <td>{person.CityName}, {person.CountryName}</td>
                            <td>{person.PhoneNumber}</td>
                            <td>{person.Languages.join(", ")}</td>
                            <td><button className={"btn btn-primary"} onClick={() => this.props.onPersonDetails(person.Id)}>SHOW</button></td>
                        </tr>
                )
            }
            </tbody>
        );
    }
}

export default PeopleTable;