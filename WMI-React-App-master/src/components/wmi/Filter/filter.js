import React from 'react';
import { Row, Col } from 'antd';
import { Card } from 'antd';
import { Input } from 'antd';
import { Select } from 'antd';


const { Option } = Select;
const { Search } = Input;



function Filter(props) {


    return (
        <Row>
            <Col span={20} offset={2}>
                <Card title="Filters" bordered={false} style={{ width: 500 }}>
                    <Search onChange={props.handlefilterChange} style={{ width: 500 }} placeholder="input search loading with enterButton" loading enterButton />
                    <br />
                    <br />
                    <Select style={{ width: 500 }} onChange={props.handleCountryChange}>
                        {props.wmiCountries.map((x) => (
                            <Option value={x.value}>
                                {x.value}
                            </Option>
                        ))}
                    </Select>
                </Card>
            </Col>
        </Row>
    );
}

export default Filter;