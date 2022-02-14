class DataSelect extends React.Component {
    
    render() {
        return (
            <select multiple={this.props.multiple} id={this.props.id} name={this.props.name} className={"form-control"} onChange={this.props.onChange} required>
                <option value={""}>Select</option>
                {
                    this.props.data.map(item =>
                        <option key={item.id} value={item.id}>{item.name}</option>
                    )
                }
            </select>
        );
    }
}

class CreateForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            cities: [],
            Name: '',
            cityId: '',
            PhoneNumber: '',
            Languages: '',
            isLoaded: false};

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.handlePhoneNumberChange = this.handlePhoneNumberChange.bind(this);
        this.handleLanguagesChange = this.handleLanguagesChange.bind(this);
    }

    render() {
        if (!this.state.isLoaded){
            return <div>Loading create form...</div>
        } else {
            return (
                <form onSubmit={this.handleSubmit}>
                    <div className={"mb-3"}>
                        <label htmlFor={"Name"}>Name</label>
                        <input id={"Name"} name={"Name"} type={"text"} className={"form-control"}
                               onChange={this.handleNameChange} required/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"CityId"}>City</label>
                        <DataSelect multiple={false} id={"CityId"} name={"CityId"} data={this.state.availableCities}
                                    onChange={this.handleCityChange}/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"PhoneNumber"}>PhoneNumber</label>
                        <input id={"PhoneNumber"} name={"PhoneNumber"} type={"text"} className={"form-control"}
                               onChange={this.handlePhoneNumberChange} required/>
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"Languages"}>Languages</label>
                        
                        <DataSelect multiple={true} id={"Languages"} name={"Languages"} data={this.state.availableLanguages}
                                    onChange={this.handleLanguagesChange}/>
                    </div>
                    <div className={"mb-3"}>
                        <button type={"submit"} className={"mb-3 btn btn-primary"}>Create Person</button>
                    </div>
                </form>
            );
        }
    }

    handleNameChange(e) {
        this.setState({Name: e.target.value});
    }

    handleCityChange(e) {
        this.setState({CityId: e.target.value});
    }

    handlePhoneNumberChange(e) {
        this.setState({PhoneNumber: e.target.value});
    }

    handleLanguagesChange(e) {

        let options = e.target.options;
        let value = [];
        for (var i = 0, l = options.length; i < l; i++) {
            if (options[i].selected) {
                value.push(options[i].value);
            }
        }
        
        this.setState({
            Languages: value
        });
    }

    handleSubmit(e) {
        e.preventDefault();
        this.props.handleSubmit({
            Name: this.state.Name,
            CityId: this.state.CityId,
            PhoneNumber: this.state.PhoneNumber,
            Languages: this.state.Languages
        });

        e.target.reset();
    }

    componentDidMount() {
        fetch("/React/GetFormData")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        availableCities: result.cities,
                        availableLanguages: result.languages,
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

export default CreateForm;