

    console.log("my name is dhruv");

    const countriesData = {
        USA: {
            states: ["New York", "California", "Texas"],
            cities: {
                "New York": ["New York City", "Buffalo"],
                California: ["Los Angeles", "San Francisco"],
                Texas: ["Houston", "Austin"],
            },
        },
        UK: {
            states: ["England", "Scotland", "Wales"],
            cities: {
                England: ["London", "Manchester"],
                Scotland: ["Edinburgh", "Glasgow"],
                Wales: ["Cardiff", "Swansea"],
            },
        },
        Canada: {
            states: ["Ontario", "Quebec", "Alberta"],
            cities: {
                Ontario: ["Toronto", "Ottawa"],
                Quebec: ["Montreal", "Quebec City"],
                Alberta: ["Calgary", "Edmonton"],
            },
        },
        India: {
            states: ["Gujarat", "Delhi", "Maharashtra", "Karnataka"],
            cities: {
                Gujarat: ["Surat", "Vadodra", "Bardoli"],
                Delhi: ["New Delhi", "Gurgaon"],
                Maharashtra: ["Mumbai", "Pune"],
                Karnataka: ["Bengaluru", "Mysore"],
            },
        },
        Japan: {
            states: ["Tokyo", "Osaka", "Kyoto"],
            cities: {
                Tokyo: ["Shinjuku", "Shibuya"],
                Osaka: ["Osaka City", "Namba"],
                Kyoto: ["Gion", "Fushimi Inari"],
            },
        },
    };

    function populateStates() {
        const countrySelect = document.getElementById("<%=ddlCountry.ClientID%>");
        const stateSelect = document.getElementById("<%=ddlState.ClientID%>");
        const selectedCountry = countrySelect.value;

        stateSelect.innerHTML =
            '<option value="" disabled selected>Select State</option>';

        if (selectedCountry && countriesData[selectedCountry]) {
            countriesData[selectedCountry].states.forEach((state) => {
                const option = document.createElement("option");
                option.value = state;
                option.textContent = state;
                stateSelect.appendChild(option);
            });
        }
    }

    function populateCities() {
        const countrySelect = document.getElementById("<%=ddlCountry.ClientID%>");
        const stateSelect = document.getElementById("<%=ddlState.ClientID%>");
        const citySelect = document.getElementById("<%=ddlCity.ClientID%>");
        const selectedCountry = countrySelect.value;
        const selectedState = stateSelect.value;

        citySelect.innerHTML =
            '<option value="" disabled selected>Select City</option>';

        if (
            selectedCountry &&
            selectedState &&
            countriesData[selectedCountry].cities[selectedState]
        ) {
            countriesData[selectedCountry].cities[selectedState].forEach((city) => {
                const option = document.createElement("option");
                option.value = city;
                option.textContent = city;
                citySelect.appendChild(option);
            });
        }
    }

    document.getElementById("<%=ddlCountry.ClientID%>").addEventListener("change", populateStates);
    document.getElementById("<%=ddlState.ClientID%>").addEventListener("change", populateCities);

