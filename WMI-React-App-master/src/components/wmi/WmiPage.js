import React, { useState, useEffect } from 'react';
import "../../App.css";
import { getCountries, getWmi, searchWmi } from "../../services/WmiService"
import { Row, Col } from 'antd';
import 'antd/dist/antd.css'; // or 'antd/dist/antd.less'
import Filter from './Filter/filter'
import TableComponent from './Table/tableComponent'
import Loader from './../Loader/Loader';
import iff from './../../utils/iff';
function WmiPage(props) {
    const [wmiData, setwmiData] = useState([]);
    const [wmiCountries, setwmiCountries] = useState([]);
    const [dataLoads, setdataLoads] = useState(false);
    const [filterText, setfilterText] = useState('');
    const [selectedCountry, setselectedCountry] = useState('');
    const [showLoader, setshowLoader] = useState(false);

    useEffect(() => {
        GetAllWMI();
        getRowsCountries();
    }, [dataLoads]);
    const GetAllWMI = async () => {
        setshowLoader(true);
        await getWmi().then(function (response) {
            // handle success
            console.log(response);
            setwmiData(response.data.items);
        })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .then(function () {
                // always executed
                setshowLoader(false);
            });
    };
    const getRowsCountries = async () => {
        setshowLoader(true);
        await getCountries().then(function (response) {
            // handle success
            const res = response.data.map(x => {
                return {
                    text: x, value: x
                }
            })
            setwmiCountries(res);
        })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .then(function () {
                // always executed
                setshowLoader(false);
            });
    }
    const search = async (filter, country) => {
        setshowLoader(true);
        searchWmi(filter, country).then(function (response) {
            // handle success
            setwmiData(response.data.items);
            // console.log(response);
        })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .then(function () {
                // always executed
                setshowLoader(false);
            });

    }
    function handleCountryChange(value) {
        value = value === null ? '' : value;
        setselectedCountry(value);
        search(filterText, value);
        console.log(`selectedCountry ${value}`);
    }
    function handlefilterChange(event) {
        // console.log(event.target.value);
        search(event.target.value, selectedCountry);
        setfilterText(event.target.value);
        // console.log(`selected ${value}`);
    }
    return (
        <Row>
            <Col span={20} offset={2}>
                {iff(showLoader, <Loader />)}
                <Filter wmiCountries={wmiCountries} handleCountryChange={handleCountryChange} handlefilterChange={handlefilterChange} />
                <TableComponent rowsData={wmiData} wmiCountries={wmiCountries} />
            </Col>
        </Row>
    );
}

export default WmiPage;