import React from 'react';
import "../../../App.css";
import { getCountries, getWmi, searchWmi } from "../../../services/WmiService"
import { Row, Col } from 'antd';
import { Table } from 'antd';
import { Card } from 'antd';


function TableComponent(props) {

    const columns = [
        {
            title: 'Name',
            dataIndex: 'name',
            // specify the condition of filtering result
            // here is that finding the name started with `value`
            onFilter: (value, record) => record.name.indexOf(value) === 0,
            sorter: (a, b) => a.name && b.name ? a.name.length - b.name.length : 0,
            sortDirections: ['descend'],
        },
        {
            title: 'WMI',
            dataIndex: 'wmi',
            defaultSortOrder: 'descend',
            sorter: (a, b) => a.wmi - b.wmi,
        },
        {
            title: 'Country',
            dataIndex: 'country',
            filters: props.wmiCountries,
            filterMultiple: true,
            onFilter: (value, record) => record.country && record.country.indexOf(value) === 0,
            sorter: (a, b) => a.country && b.country ? a.country.length - b.country.length : 0,
            sortDirections: ['descend', 'ascend'],
        },
        {
            title: 'CreatedOn',
            dataIndex: 'createdOn',
            defaultSortOrder: 'descend',
            sorter: (a, b) => a.createdOn && b.createdOn ? a.createdOn - b.createdOn : 0,
        },
        {
            title: 'VehicleType',
            dataIndex: 'vehicleType',
            defaultSortOrder: 'descend',
            sorter: (a, b) => a.vehicleType && b.vehicleType ? a.vehicleType - b.vehicleType : 0,
        }
    ];



    function onChange(pagination, filters, sorter, extra) {
        console.log('params', pagination, filters, sorter, extra);
    }
    return (
        <Row>
            <Col span={20} offset={2}>
                <Card title="WMI Data" bordered={false} >
                    <div className="App">
                        <header>WMI Data - Honda | Total: {props.rowsData.length}</header>
                        <Table columns={columns} dataSource={props.rowsData} onChange={onChange} />
                    </div>
                </Card>

            </Col>
        </Row>
    );
}

export default TableComponent;