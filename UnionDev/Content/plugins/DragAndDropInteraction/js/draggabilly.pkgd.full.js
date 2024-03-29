﻿/*!
 * Draggabilly PACKAGED v1.1.1
 * Make that shiz draggable
 * http://draggabilly.desandro.com
 * MIT license
 */

! function (a) {
    function b(a) {
        return new RegExp("(^|\\s+)" + a + "(\\s+|$)")
    }

    function c(a, b) {
        var c = d(a, b) ? f : e;
        c(a, b)
    }
    var d, e, f;
    "classList" in document.documentElement ? (d = function (a, b) {
        return a.classList.contains(b)
    }, e = function (a, b) {
        a.classList.add(b)
    }, f = function (a, b) {
        a.classList.remove(b)
    }) : (d = function (a, c) {
        return b(c).test(a.className)
    }, e = function (a, b) {
        d(a, b) || (a.className = a.className + " " + b)
    }, f = function (a, c) {
        a.className = a.className.replace(b(c), " ")
    });
    var g = {
        hasClass: d,
        addClass: e,
        removeClass: f,
        toggleClass: c,
        has: d,
        add: e,
        remove: f,
        toggle: c
    };
    "function" == typeof define && define.amd ? define("classie/classie", g) : a.classie = g
}(window),
function () {
    function a() { }

    function b(a, b) {
        for (var c = a.length; c--;)
            if (a[c].listener === b) return c;
        return -1
    }

    function c(a) {
        return function () {
            return this[a].apply(this, arguments)
        }
    }
    var d = a.prototype;
    d.getListeners = function (a) {
        var b, c, d = this._getEvents();
        if ("object" == typeof a) {
            b = {};
            for (c in d) d.hasOwnProperty(c) && a.test(c) && (b[c] = d[c])
        } else b = d[a] || (d[a] = []);
        return b
    }, d.flattenListeners = function (a) {
        var b, c = [];
        for (b = 0; b < a.length; b += 1) c.push(a[b].listener);
        return c
    }, d.getListenersAsObject = function (a) {
        var b, c = this.getListeners(a);
        return c instanceof Array && (b = {}, b[a] = c), b || c
    }, d.addListener = function (a, c) {
        var d, e = this.getListenersAsObject(a),
            f = "object" == typeof c;
        for (d in e) e.hasOwnProperty(d) && -1 === b(e[d], c) && e[d].push(f ? c : {
            listener: c,
            once: !1
        });
        return this
    }, d.on = c("addListener"), d.addOnceListener = function (a, b) {
        return this.addListener(a, {
            listener: b,
            once: !0
        })
    }, d.once = c("addOnceListener"), d.defineEvent = function (a) {
        return this.getListeners(a), this
    }, d.defineEvents = function (a) {
        for (var b = 0; b < a.length; b += 1) this.defineEvent(a[b]);
        return this
    }, d.removeListener = function (a, c) {
        var d, e, f = this.getListenersAsObject(a);
        for (e in f) f.hasOwnProperty(e) && (d = b(f[e], c), -1 !== d && f[e].splice(d, 1));
        return this
    }, d.off = c("removeListener"), d.addListeners = function (a, b) {
        return this.manipulateListeners(!1, a, b)
    }, d.removeListeners = function (a, b) {
        return this.manipulateListeners(!0, a, b)
    }, d.manipulateListeners = function (a, b, c) {
        var d, e, f = a ? this.removeListener : this.addListener,
            g = a ? this.removeListeners : this.addListeners;
        if ("object" != typeof b || b instanceof RegExp)
            for (d = c.length; d--;) f.call(this, b, c[d]);
        else
            for (d in b) b.hasOwnProperty(d) && (e = b[d]) && ("function" == typeof e ? f.call(this, d, e) : g.call(this, d, e));
        return this
    }, d.removeEvent = function (a) {
        var b, c = typeof a,
            d = this._getEvents();
        if ("string" === c) delete d[a];
        else if ("object" === c)
            for (b in d) d.hasOwnProperty(b) && a.test(b) && delete d[b];
        else delete this._events;
        return this
    }, d.emitEvent = function (a, b) {
        var c, d, e, f, g = this.getListenersAsObject(a);
        for (e in g)
            if (g.hasOwnProperty(e))
                for (d = g[e].length; d--;) c = g[e][d], f = c.listener.apply(this, b || []), (f === this._getOnceReturnValue() || c.once === !0) && this.removeListener(a, c.listener);
        return this
    }, d.trigger = c("emitEvent"), d.emit = function (a) {
        var b = Array.prototype.slice.call(arguments, 1);
        return this.emitEvent(a, b)
    }, d.setOnceReturnValue = function (a) {
        return this._onceReturnValue = a, this
    }, d._getOnceReturnValue = function () {
        return this.hasOwnProperty("_onceReturnValue") ? this._onceReturnValue : !0
    }, d._getEvents = function () {
        return this._events || (this._events = {})
    }, "function" == typeof define && define.amd ? define("eventEmitter/EventEmitter", [], function () {
        return a
    }) : "object" == typeof module && module.exports ? module.exports = a : this.EventEmitter = a
}.call(this),
    function (a) {
        var b = document.documentElement,
            c = function () { };
        b.addEventListener ? c = function (a, b, c) {
            a.addEventListener(b, c, !1)
        } : b.attachEvent && (c = function (b, c, d) {
            b[c + d] = d.handleEvent ? function () {
                var b = a.event;
                b.target = b.target || b.srcElement, d.handleEvent.call(d, b)
            } : function () {
                var c = a.event;
                c.target = c.target || c.srcElement, d.call(b, c)
            }, b.attachEvent("on" + c, b[c + d])
        });
        var d = function () { };
        b.removeEventListener ? d = function (a, b, c) {
            a.removeEventListener(b, c, !1)
        } : b.detachEvent && (d = function (a, b, c) {
            a.detachEvent("on" + b, a[b + c]);
            try {
                delete a[b + c]
            } catch (d) {
                a[b + c] = void 0
            }
        });
        var e = {
            bind: c,
            unbind: d
        };
        "function" == typeof define && define.amd ? define("eventie/eventie", e) : a.eventie = e
    }(this),
    function (a) {
        function b(a) {
            if (a) {
                if ("string" == typeof d[a]) return a;
                a = a.charAt(0).toUpperCase() + a.slice(1);
                for (var b, e = 0, f = c.length; f > e; e++)
                    if (b = c[e] + a, "string" == typeof d[b]) return b
            }
        }
        var c = "Webkit Moz ms Ms O".split(" "),
            d = document.documentElement.style;
        "function" == typeof define && define.amd ? define("get-style-property/get-style-property", [], function () {
            return b
        }) : a.getStyleProperty = b
    }(window),
    function (a) {
        function b(a) {
            var b = parseFloat(a),
                c = -1 === a.indexOf("%") && !isNaN(b);
            return c && b
        }

        function c() {
            for (var a = {
                width: 0,
                height: 0,
                innerWidth: 0,
                innerHeight: 0,
                outerWidth: 0,
                outerHeight: 0
            }, b = 0, c = g.length; c > b; b++) {
                var d = g[b];
                a[d] = 0
            }
            return a
        }

        function d(a) {
            function d(a) {
                if ("string" == typeof a && (a = document.querySelector(a)), a && "object" == typeof a && a.nodeType) {
                    var d = f(a);
                    if ("none" === d.display) return c();
                    var i = {};
                    i.width = a.offsetWidth, i.height = a.offsetHeight;
                    for (var j = i.isBorderBox = !(!h || !d[h] || "border-box" !== d[h]), k = 0, l = g.length; l > k; k++) {
                        var m = g[k],
                            n = d[m],
                            o = parseFloat(n);
                        i[m] = isNaN(o) ? 0 : o
                    }
                    var p = i.paddingLeft + i.paddingRight,
                        q = i.paddingTop + i.paddingBottom,
                        r = i.marginLeft + i.marginRight,
                        s = i.marginTop + i.marginBottom,
                        t = i.borderLeftWidth + i.borderRightWidth,
                        u = i.borderTopWidth + i.borderBottomWidth,
                        v = j && e,
                        w = b(d.width);
                    w !== !1 && (i.width = w + (v ? 0 : p + t));
                    var x = b(d.height);
                    return x !== !1 && (i.height = x + (v ? 0 : q + u)), i.innerWidth = i.width - (p + t), i.innerHeight = i.height - (q + u), i.outerWidth = i.width + r, i.outerHeight = i.height + s, i
                }
            }
            var e, h = a("boxSizing");
            return function () {
                if (h) {
                    var a = document.createElement("div");
                    a.style.width = "200px", a.style.padding = "1px 2px 3px 4px", a.style.borderStyle = "solid", a.style.borderWidth = "1px 2px 3px 4px", a.style[h] = "border-box";
                    var c = document.body || document.documentElement;
                    c.appendChild(a);
                    var d = f(a);
                    e = 200 === b(d.width), c.removeChild(a)
                }
            }(), d
        }
        var e = document.defaultView,
            f = e && e.getComputedStyle ? function (a) {
                return e.getComputedStyle(a, null)
            } : function (a) {
                return a.currentStyle
            },
            g = ["paddingLeft", "paddingRight", "paddingTop", "paddingBottom", "marginLeft", "marginRight", "marginTop", "marginBottom", "borderLeftWidth", "borderRightWidth", "borderTopWidth", "borderBottomWidth"];
        "function" == typeof define && define.amd ? define("get-size/get-size", ["get-style-property/get-style-property"], d) : a.getSize = d(a.getStyleProperty)
    }(window),
    function (a) {
        function b(a, b) {
            for (var c in b) a[c] = b[c];
            return a
        }

        function c() { }

        function d(d, e, g, j, k) {
            function m(a, c) {
                this.element = "string" == typeof a ? f.querySelector(a) : a, this.options = b({}, this.options), b(this.options, c), this._create()
            }

            function n() {
                return !1
            }

            function o(a, b) {
                a.x = void 0 !== b.pageX ? b.pageX : b.clientX, a.y = void 0 !== b.pageY ? b.pageY : b.clientY
            }

            function p(a, b, c) {
                return c = c || "round", b ? Math[c](a / b) * b : a
            }
            var q = j("transform"),
                r = !!j("perspective");
            b(m.prototype, e.prototype), m.prototype.options = {}, m.prototype._create = function () {
                this.position = {}, this._getPosition(), this.startPoint = {
                    x: 0,
                    y: 0
                }, this.dragPoint = {
                    x: 0,
                    y: 0
                }, this.startPosition = b({}, this.position);
                var a = h(this.element);
                "relative" !== a.position && "absolute" !== a.position && (this.element.style.position = "relative"), this.enable(), this.setHandles()
            }, m.prototype.setHandles = function () {
                this.handles = this.options.handle ? this.element.querySelectorAll(this.options.handle) : [this.element];
                for (var b = 0, c = this.handles.length; c > b; b++) {
                    var d = this.handles[b];
                    a.navigator.pointerEnabled ? (g.bind(d, "pointerdown", this), d.style.touchAction = "none") : a.navigator.msPointerEnabled ? (g.bind(d, "MSPointerDown", this), d.style.msTouchAction = "none") : (g.bind(d, "mousedown", this), g.bind(d, "touchstart", this), t(d))
                }
            };
            var s = "attachEvent" in f.documentElement,
                t = s ? function (a) {
                    "IMG" === a.nodeName && (a.ondragstart = n);
                    for (var b = a.querySelectorAll("img"), c = 0, d = b.length; d > c; c++) {
                        var e = b[c];
                        e.ondragstart = n
                    }
                } : c;
            m.prototype._getPosition = function () {
                var a = h(this.element),
                    b = parseInt(a.left, 10),
                    c = parseInt(a.top, 10);
                this.position.x = isNaN(b) ? 0 : b, this.position.y = isNaN(c) ? 0 : c, this._addTransformPosition(a)
            }, m.prototype._addTransformPosition = function (a) {
                if (q) {
                    var b = a[q];
                    if (0 === b.indexOf("matrix")) {
                        var c = b.split(","),
                            d = 0 === b.indexOf("matrix3d") ? 12 : 4,
                            e = parseInt(c[d], 10),
                            f = parseInt(c[d + 1], 10);
                        this.position.x += e, this.position.y += f
                    }
                }
            }, m.prototype.handleEvent = function (a) {
                var b = "on" + a.type;
                this[b] && this[b](a)
            }, m.prototype.getTouch = function (a) {
                for (var b = 0, c = a.length; c > b; b++) {
                    var d = a[b];
                    if (d.identifier === this.pointerIdentifier) return d
                }
            }, m.prototype.onmousedown = function (a) {
                var b = a.button;
                b && 0 !== b && 1 !== b || this.dragStart(a, a)
            }, m.prototype.ontouchstart = function (a) {
                this.isDragging || this.dragStart(a, a.changedTouches[0])
            }, m.prototype.onMSPointerDown = m.prototype.onpointerdown = function (a) {
                this.isDragging || this.dragStart(a, a)
            };
            var u = {
                mousedown: ["mousemove", "mouseup"],
                touchstart: ["touchmove", "touchend", "touchcancel"],
                pointerdown: ["pointermove", "pointerup", "pointercancel"],
                MSPointerDown: ["MSPointerMove", "MSPointerUp", "MSPointerCancel"]
            };
            m.prototype.dragStart = function (b, c) {
                this.isEnabled && (b.preventDefault ? b.preventDefault() : b.returnValue = !1, this.pointerIdentifier = void 0 !== c.pointerId ? c.pointerId : c.identifier, this._getPosition(), this.measureContainment(), o(this.startPoint, c), this.startPosition.x = this.position.x, this.startPosition.y = this.position.y, this.setLeftTop(), this.dragPoint.x = 0, this.dragPoint.y = 0, this._bindEvents({
                    events: u[b.type],
                    node: b.preventDefault ? a : f
                }), d.add(this.element, "is-dragging"), this.isDragging = !0, this.emitEvent("dragStart", [this, b, c]), this.animate())
            }, m.prototype._bindEvents = function (a) {
                for (var b = 0, c = a.events.length; c > b; b++) {
                    var d = a.events[b];
                    g.bind(a.node, d, this)
                }
                this._boundEvents = a
            }, m.prototype._unbindEvents = function () {
                var a = this._boundEvents;
                if (a && a.events) {
                    for (var b = 0, c = a.events.length; c > b; b++) {
                        var d = a.events[b];
                        g.unbind(a.node, d, this)
                    }
                    delete this._boundEvents
                }
            }, m.prototype.measureContainment = function () {
                var a = this.options.containment;
                if (a) {
                    this.size = k(this.element);
                    var b = this.element.getBoundingClientRect(),
                        c = i(a) ? a : "string" == typeof a ? f.querySelector(a) : this.element.parentNode;
                    this.containerSize = k(c);
                    var d = c.getBoundingClientRect();
                    this.relativeStartPosition = {
                        x: b.left - d.left,
                        y: b.top - d.top
                    }
                }
            }, m.prototype.onmousemove = function (a) {
                this.dragMove(a, a)
            }, m.prototype.onMSPointerMove = m.prototype.onpointermove = function (a) {
                a.pointerId === this.pointerIdentifier && this.dragMove(a, a)
            }, m.prototype.ontouchmove = function (a) {
                var b = this.getTouch(a.changedTouches);
                b && this.dragMove(a, b)
            }, m.prototype.dragMove = function (a, b) {
                o(this.dragPoint, b);
                var c = this.dragPoint.x - this.startPoint.x,
                    d = this.dragPoint.y - this.startPoint.y,
                    e = this.options.grid,
                    f = e && e[0],
                    g = e && e[1];
                c = p(c, f), d = p(d, g), c = this.containDrag("x", c, f), d = this.containDrag("y", d, g), c = "y" === this.options.axis ? 0 : c, d = "x" === this.options.axis ? 0 : d, this.position.x = this.startPosition.x + c, this.position.y = this.startPosition.y + d, this.dragPoint.x = c, this.dragPoint.y = d, this.emitEvent("dragMove", [this, a, b])
            }, m.prototype.containDrag = function (a, b, c) {
                if (!this.options.containment) return b;
                var d = "x" === a ? "width" : "height",
                    e = this.relativeStartPosition[a],
                    f = p(-e, c, "ceil"),
                    g = this.containerSize[d] - e - this.size[d];
                return g = p(g, c, "floor"), Math.min(g, Math.max(f, b))
            }, m.prototype.onmouseup = function (a) {
                this.dragEnd(a, a)
            }, m.prototype.onMSPointerUp = m.prototype.onpointerup = function (a) {
                a.pointerId === this.pointerIdentifier && this.dragEnd(a, a)
            }, m.prototype.ontouchend = function (a) {
                var b = this.getTouch(a.changedTouches);
                b && this.dragEnd(a, b)
            }, m.prototype.dragEnd = function (a, b) {
                this.isDragging = !1, delete this.pointerIdentifier, q && (this.element.style[q] = "", this.setLeftTop()), this._unbindEvents(), d.remove(this.element, "is-dragging"), this.emitEvent("dragEnd", [this, a, b])
            }, m.prototype.onMSPointerCancel = m.prototype.onpointercancel = function (a) {
                a.pointerId === this.pointerIdentifier && this.dragEnd(a, a)
            }, m.prototype.ontouchcancel = function (a) {
                var b = this.getTouch(a.changedTouches);
                this.dragEnd(a, b)
            }, m.prototype.animate = function () {
                if (this.isDragging) {
                    this.positionDrag();
                    var a = this;
                    l(function () {
                        a.animate()
                    })
                }
            };
            var v = r ? function (a, b) {
                return "translate3d( " + a + "px, " + b + "px, 0)"
            } : function (a, b) {
                return "translate( " + a + "px, " + b + "px)"
            };
            return m.prototype.setLeftTop = function () {
                this.element.style.left = this.position.x + "px", this.element.style.top = this.position.y + "px"
            }, m.prototype.positionDrag = q ? function () {
                this.element.style[q] = v(this.dragPoint.x, this.dragPoint.y)
            } : m.prototype.setLeftTop, m.prototype.enable = function () {
                this.isEnabled = !0
            }, m.prototype.disable = function () {
                this.isEnabled = !1, this.isDragging && this.dragEnd()
            }, m
        }
        for (var e, f = a.document, g = f.defaultView, h = g && g.getComputedStyle ? function (a) {
                return g.getComputedStyle(a, null)
        } : function (a) {
                return a.currentStyle
        }, i = "object" == typeof HTMLElement ? function (a) {
                return a instanceof HTMLElement
        } : function (a) {
                return a && "object" == typeof a && 1 === a.nodeType && "string" == typeof a.nodeName
        }, j = 0, k = "webkit moz ms o".split(" "), l = a.requestAnimationFrame, m = a.cancelAnimationFrame, n = 0; n < k.length && (!l || !m) ; n++) e = k[n], l = l || a[e + "RequestAnimationFrame"], m = m || a[e + "CancelAnimationFrame"] || a[e + "CancelRequestAnimationFrame"];
        l && m || (l = function (b) {
            var c = (new Date).getTime(),
                d = Math.max(0, 16 - (c - j)),
                e = a.setTimeout(function () {
                    b(c + d)
                }, d);
            return j = c + d, e
        }, m = function (b) {
            a.clearTimeout(b)
        }), "function" == typeof define && define.amd ? define(["classie/classie", "eventEmitter/EventEmitter", "eventie/eventie", "get-style-property/get-style-property", "get-size/get-size"], d) : "object" == typeof exports ? module.exports = d(require("desandro-classie"), require("wolfy87-eventemitter"), require("eventie"), require("desandro-get-style-property"), require("get-size")) : a.Draggabilly = d(a.classie, a.EventEmitter, a.eventie, a.getStyleProperty, a.getSize)
    }(window);